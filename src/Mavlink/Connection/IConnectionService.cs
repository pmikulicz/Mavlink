using System;

namespace Mavlink.Connection
{
    public interface IConnectionService : IDisposable
    {
        void Write(byte[] buffer);

        int Read(byte[] buffer, int bufferSize);
    }
}