using System;
using System.Net;
using System.Net.Sockets;
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
            await accepted.GetStream().WriteAsync(message);
        }
    }
}
