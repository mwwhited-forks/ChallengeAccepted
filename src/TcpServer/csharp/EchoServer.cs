using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public class EchoServer : ServerBase
    {
        public EchoServer(IPAddress? ipAddress = default, ushort port = 7)
            : base(ipAddress, port)
        {
        }

        protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"EchoServer: {clientId}-{Thread.CurrentThread.ManagedThreadId}: {Encoding.UTF8.GetString(message.ToArray())}");
            await accepted.GetStream().WriteAsync(message);
        }
    }
}
