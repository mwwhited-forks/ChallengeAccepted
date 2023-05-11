using System;
using System.Threading.Tasks;

namespace TcpServer
{
    public interface IServerBase : IAsyncDisposable
    {
        void Start();
        Task<IAsyncDisposable> Stop();
    }
}
