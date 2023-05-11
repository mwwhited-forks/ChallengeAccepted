using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new List<IServerBase>()
            {
                new EchoServer(),
                new DiscardServer(),
                new DaytimeServer(),
                new ChargenServer(),
            };
            foreach (var service in services)
            {
                service.Start();
            }

            Console.WriteLine("Running!");
            Console.ReadLine();
        }
    }

    public class ChargenServer : ServerBase
    {
        public ChargenServer(IPAddress? ipAddress = default, ushort port = 19)
            : base(ipAddress, port)
        {
        }

        protected override async Task OnStartAsync(CancellationToken cancellationToken)
        {
            var rand = new Random();
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach(var client in Clients)
                {
                    if (rand.NextDouble() > 0.5) continue;
                    Memory<byte> buffer = Guid.NewGuid().ToByteArray();
                    await client.Value.GetStream().WriteAsync(buffer);
                }

                await Task.Delay(1000);
            }
        }

        protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"ChargenServer: {clientId}-{Thread.CurrentThread.ManagedThreadId}: {Encoding.UTF8.GetString(message.ToArray())}");

            //Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
            //await accepted.GetStream().WriteAsync(buffer);

            return Task.CompletedTask;
        }
    }
}
