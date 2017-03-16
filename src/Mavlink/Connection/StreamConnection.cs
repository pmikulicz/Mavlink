using System;
using System.IO;

namespace Mavlink.Connection
{
    public sealed class StreamConnection : IConnectionService
    {
        private readonly Stream _stream;
        private bool _disposed;

        public StreamConnection(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            _stream = stream;
        }

       

        public void Write(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            _stream.Write(buffer, 0, buffer.Length);
        }

        public int Read(byte[] buffer, int bufferSize)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            return  _stream.Read(buffer, 0, bufferSize);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
                
                _stream.Dispose();
            
            _disposed = true;
        }

        ~StreamConnection()
        {
            Dispose(false);
        }
    }
}