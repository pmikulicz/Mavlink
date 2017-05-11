// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SocketConnection.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Implementation of service which makes use of socket connection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Sockets;

namespace Mavlink.Connection
{
    /// <summary>
    /// Implementation of service which makes use of socket connection
    /// </summary>
    public sealed class SocketConnection : ConnectionService
    {
        private readonly Socket _socket;

        public SocketConnection(Socket socket)
        {
            _socket = socket ?? throw new ArgumentNullException(nameof(socket));
        }

        protected override void ProcessWrite(byte[] buffer)
        {
            _socket.Send(buffer);
        }

        protected override int ProcessRead(byte[] buffer)
        {
            _socket.ReceiveBufferSize = BufferSize;

            return _socket.Receive(buffer);
        }

        protected override void ProcessDispose()
        {
            _socket.Dispose();
        }
    }
}