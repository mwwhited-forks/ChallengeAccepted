using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer;

public class DaytimeServer(IPAddress? ipAddress = default, ushort port = 13) : ServerBase(ipAddress, port)
{
    protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, ReadOnlyMemory<byte> message, CancellationToken cancellationToken)
    {
        Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
        await accepted.GetStream().WriteAsync(buffer, cancellationToken);
    }
}
