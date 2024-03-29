﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer;

public class DiscardServer(IPAddress? ipAddress = default, ushort port = 9) : ServerBase(ipAddress, port)
{
    protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, ReadOnlyMemory<byte> message, CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
