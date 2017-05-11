// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectionService.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of service responsible for sending and receiving bytes from established connection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Connection
{
    /// <summary>
    /// Interface of service responsible for sending and receiving bytes from established connection
    /// </summary>
    public interface IConnectionService : IDisposable
    {
        /// <summary>
        /// Writes bytes array to established connection
        /// </summary>
        /// <param name="buffer">Bytes array to be written</param>
        void Write(byte[] buffer);

        /// <summary>
        /// Reads bytes to buffer from established connection
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        int Read(byte[] buffer);

        /// <summary>
        /// Gets or sets buffer size
        /// </summary>
        int BufferSize { get; set; }

        /// <summary>
        /// Gets bytes read from established connection
        /// </summary>
        int BytesRead { get; }

        /// <summary>
        /// Gets bytes sent to established connection
        /// </summary>
        int BytesSent { get; }
    }
}