// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionService.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Abstract implementation of connection service which implements bytes counter mechanism and IDisposable pattern
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Connection
{
    /// <summary>
    /// Abstract implementation of connection service which implements bytes counter mechanism and IDisposable pattern
    /// </summary>
    public abstract class ConnectionService : IConnectionService
    {
        private bool _disposed;

        protected ConnectionService()
        {
            BytesRead = 0;
            BytesSent = 0;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public void Write(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            ProcessWrite(buffer);
            BytesSent += buffer.Length;
        }

        /// <inheritdoc />
        public int Read(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            int bytesRead = ProcessRead(buffer);
            BytesRead += bytesRead;

            return bytesRead;
        }

        /// <inheritdoc />
        public int BufferSize { get; set; } = 1024;

        /// <inheritdoc />
        public int BytesRead { get; protected set; }

        /// <inheritdoc />
        public int BytesSent { get; protected set; }

        ~ConnectionService()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
                ProcessDispose();

            _disposed = true;
        }

        protected abstract void ProcessDispose();

        protected abstract void ProcessWrite(byte[] buffer);

        protected abstract int ProcessRead(byte[] buffer);
    }
}