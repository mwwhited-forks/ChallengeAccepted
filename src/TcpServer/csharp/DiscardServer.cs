using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public class DiscardServer : ServerBase
    {
        public DiscardServer(IPAddress? ipAddress = default, ushort port = 9)
            : base(ipAddress, port)
        {
        }

        protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"DiscardServer: {clientId}-{Thread.CurrentThread.ManagedThreadId}: {Encoding.UTF8.GetString(message.ToArray())}");
            return Task.CompletedTask;
        }
    }
}
