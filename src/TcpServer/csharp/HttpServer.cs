using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer;

public class HttpServer(
    string webRootPath,
    string defaultFileName = "index.html",
    IPAddress? ipAddress = default,
    ushort port = 80
    ) : ServerBase(ipAddress, port)
{
    private readonly string _webRootPath = Path.GetFullPath(webRootPath);
    // https://www.rfc-editor.org/rfc/rfc2616
    // https://www.rfc-editor.org/rfc/rfc7230

    protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, ReadOnlyMemory<byte> message, CancellationToken cancellationToken)
    {
        var httpRequest = new HttpRequest(message);

        var uri = new Uri(string.IsNullOrWhiteSpace(httpRequest.Resource) ? "/" : httpRequest.Resource, UriKind.RelativeOrAbsolute);

        if (!uri.IsAbsoluteUri && httpRequest.Headers.TryGetValue("Host", out var host))
        {
            uri = new Uri($"http://{host}{uri}", UriKind.RelativeOrAbsolute);
        }

        var path = Path.GetFullPath(Path.Combine(_webRootPath, "./" + uri.LocalPath.TrimStart('/', '\\')));
        if (!path.StartsWith(_webRootPath))
            throw new UnauthorizedAccessException();

        if (uri.LocalPath.ToString().EndsWith('/'))
            path = Path.Combine(path, defaultFileName);

        HttpResponse response;

        Console.WriteLine($"{httpRequest.Method}: {path}");

        if (httpRequest.Method != "GET")
            response = new HttpResponse(501, $"Method {httpRequest.Method} Not Implmented");
        else if (File.Exists(path))
            response = new HttpResponse(200, "OK", File.ReadAllBytes(path));
        else
            response = new HttpResponse(404, "Not Found");

        var output = await response.GenerateOutputAsync();

        var outStream = accepted.GetStream();

        await outStream.WriteAsync(output, cancellationToken);
        outStream.Close();
    }

    public record HttpRequest
    {
        public HttpRequest(
            ReadOnlyMemory<byte> buffer
            )
        {
            using var stream = new MemoryStream(buffer.ToArray());
            stream.Position = 0;
            using var reader = new StreamReader(stream);

            var request = reader.ReadLine()?.Split(' ');
            if (request == null)
                return;

            Method = request[0];
            Resource = request[1];
            Protocol = request[1];

            var list = new Dictionary<string, string>();
            while (!reader.EndOfStream)
            {
                var headerLine = reader.ReadLine()?.Split(':', 2);
                if (string.IsNullOrEmpty(headerLine?[0]))
                    break;

                list.TryAdd(headerLine[0].Trim(), headerLine[1].Trim());
            }

            Headers = list;
            Content = buffer[(int)stream.Position..];
        }

        public string Method { get; init; }
        public string Resource { get; init; }
        public string Protocol { get; init; }

        public IDictionary<string, string> Headers { get; init; }

        public ReadOnlyMemory<byte> Content { get; init; }
    }

    public record HttpResponse
    {
        public HttpResponse(
            int statusCode,
            string statusMessage,
            ReadOnlyMemory<byte>? buffer = default,
            IDictionary<string, string>? header = default
            )
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Headers = header ?? new Dictionary<string, string>();
            Content = buffer ?? Array.Empty<byte>();
        }

        public int StatusCode { get; init; }
        public string StatusMessage { get; init; }

        public IDictionary<string, string> Headers { get; init; }

        public ReadOnlyMemory<byte> Content { get; init; }

        public async Task<ReadOnlyMemory<byte>> GenerateOutputAsync()
        {
            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms) { AutoFlush = true, };
            await writer.WriteLineAsync($"HTTP/1.1 {StatusCode} {StatusMessage}");

            foreach (var header in Headers)
                await writer.WriteLineAsync($"{header.Key}: {header.Value}");

            await writer.WriteLineAsync("");

            await ms.WriteAsync(Content.ToArray());

            return ms.ToArray();
        }
    }
}