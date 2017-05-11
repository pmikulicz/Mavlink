// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamConnection.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Implementation of service which makes use of stream connection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

namespace Mavlink.Connection
{
    /// <summary>
    /// Implementation of service which makes use of stream connection
    /// </summary>
    public sealed class StreamConnection : ConnectionService
    {
        private readonly Stream _stream;

        public StreamConnection(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        protected override void ProcessWrite(byte[] buffer)
        {
            _stream.Write(buffer, 0, buffer.Length);
        }

        protected override int ProcessRead(byte[] buffer)
        {
            return _stream.Read(buffer, 0, BufferSize);
        }

        protected override void ProcessDispose()
        {
            _stream.Dispose();
        }
    }
}