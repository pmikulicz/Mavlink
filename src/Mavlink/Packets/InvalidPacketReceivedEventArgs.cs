// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPacketReceivedEventArgs.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents event argument that is used to provide data for the InvalidPacketReceived event
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents event argument that is used to provide data for the InvalidPacketReceived event
    /// </summary>
    internal sealed class InvalidPacketReceivedEventArgs
    {
        public InvalidPacketReceivedEventArgs(byte[] paketBytes)
        {
            if (paketBytes == null)
                throw new ArgumentNullException(nameof(paketBytes));

            PaketBytes = paketBytes;
        }

        /// <summary>
        /// Gets byte array of invalid packet
        /// </summary>
        public byte[] PaketBytes { get; }
    }
}