using System;
using System.Threading.Tasks;

namespace Mavlink.Communication
{
    public interface ICommunicationService : IDisposable
    {
        Task WriteAsync(byte[] buffer);

        int Read(byte[] buffer);
    }
}