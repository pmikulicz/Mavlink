using System;
using System.Net.Sockets;

namespace Mavlink.Connection
{
    internal sealed class SocketConnection : IConnectionService
    {
        private readonly Socket _socket;
        private bool _disposed;

        public SocketConnection(Socket socket)
        {
            if (socket == null)
                throw new ArgumentNullException(nameof(socket));

            _socket = socket;
        }

        
        public void Write(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            _socket.Send(buffer);
        }

        public int Read(byte[] buffer, int bufferSize)
        {
            _socket.ReceiveBufferSize = bufferSize;

            return _socket.Receive(buffer);
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

                _socket.Dispose();

            _disposed = true;
        }

        ~SocketConnection()
        {
            Dispose(false);
        }
    }
}