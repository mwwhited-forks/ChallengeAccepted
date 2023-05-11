using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public class DaytimeServer : ServerBase
    {
        public DaytimeServer(IPAddress? ipAddress = default, ushort port = 13)
            : base(ipAddress, port)
        {
        }

        protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"DaytimeServer: {clientId}-{Thread.CurrentThread.ManagedThreadId}: {Encoding.UTF8.GetString(message.ToArray())}");

            Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
            await accepted.GetStream().WriteAsync(buffer);
        }
    }
}
