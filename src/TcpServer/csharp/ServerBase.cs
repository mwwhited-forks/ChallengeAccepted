using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public abstract class ServerBase : IServerBase
    {
        protected IPAddress IPAddress { get; init; }
        protected ushort Port { get; init; }

        protected ServerBase(IPAddress? ipAddress = default, ushort port = 65535)
        {
            IPAddress = ipAddress ?? IPAddress.Loopback;
            Port = port;
        }

        public void Start()
        {
            if (_listener != null) throw new ApplicationException("Already Started!");
            _listener = new TcpListener(IPAddress, Port);
            _listener.Start();
            var _cts = new CancellationTokenSource();

            var serviceLoopTask = Task.Run(() => ServiceLoopAsync(_listener, _cts.Token));
            var startTask = Task.Run(() => OnStartAsync(_cts.Token));

            _task = Task.WhenAll(serviceLoopTask, startTask);
        }

        protected virtual Task OnStartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public async Task<IAsyncDisposable> Stop()
        {
            _cts.Cancel();
            await Task.Yield();

            foreach (var client in _clients)
            {
                if (client.Value.Connected)
                {
                    client.Value.Close();
                    await Task.Yield();
                }
            }

            _listener.Stop();
            await Task.Yield();
            return this;
        }

        protected async Task ServiceLoopAsync(TcpListener listener, CancellationToken cancellationToken)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            var clientIdSeed = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var accepted = await listener.AcceptTcpClientAsync();
                var clientId = clientIdSeed++;
                _clients.Add(clientId, accepted);


                var clientTask = Task.Run(async () =>
                {
                    Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Accepted: {clientId}-{Thread.CurrentThread.ManagedThreadId}");
                    await AcceptClientAsync(clientId, accepted, cts.Token);
                    Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Closed:   {clientId}-{Thread.CurrentThread.ManagedThreadId}");
                });
                _tasks.Add(clientTask);

                await Task.Yield();

                var areCompleted = _tasks.Where(t => t.IsCompleted).ToArray();
                foreach (var completed in areCompleted)
                    _tasks.Remove(completed);

                var areNotCollected = _clients.Where(c => !c.Value.Connected).ToArray();
                foreach (var notCollected in areNotCollected)
                    _clients.Remove(notCollected.Key);
            }
        }

        protected virtual async Task AcceptClientAsync(int clientId, TcpClient accepted, CancellationToken cancellationToken)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            using var stream = accepted.GetStream();
            while (!cancellationToken.IsCancellationRequested)
            {
                if (stream.CanRead)
                {
                    Memory<byte> buffer = new byte[1024];
                    var readLength = await stream.ReadAsync(buffer, cts.Token);
                    if (readLength > 0)
                    {
                        var sliced = buffer.Slice(0, readLength);
                        await MessageReceivedAsync(clientId, accepted, sliced, cts.Token);
                    }
                    else if (readLength == -1)
                    {
                        break;
                    }
                }
                await Task.Yield();
            }
        }

        protected abstract Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken);

        private CancellationTokenSource? _cts;
        private TcpListener? _listener;
        private Task? _task;
        private readonly Dictionary<int, TcpClient> _clients = new();
        private readonly List<Task> _tasks = new();

        protected IReadOnlyDictionary<int, TcpClient> Clients => _clients;

        public async ValueTask DisposeAsync()
        {
            _cts.Cancel();
            _listener.Stop();

            await Task.Yield();

            await Task.WhenAll(
                _task,
                Task.WhenAll(_tasks)
                );

            await Task.Yield();

            foreach (var client in _clients)
            {
                client.Value.Dispose();
                await Task.Yield();
            }

            await Task.Yield();

            _cts.Dispose();
        }
    }
}
