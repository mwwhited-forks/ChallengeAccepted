using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer;

public class EchoServer(IPAddress? ipAddress = default, ushort port = 7) : ServerBase(ipAddress, port)
{
    protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, ReadOnlyMemory<byte> message, CancellationToken cancellationToken)
    {
        await accepted.GetStream().WriteAsync(message, cancellationToken);
    }
}
