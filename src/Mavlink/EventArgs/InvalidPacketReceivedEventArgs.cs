// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPacketReceivedEventArgs.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents event argument that is used to provide data for the InvalidPacketReceived event
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink
{
    /// <summary>
    ///  Represents event argument that is used to provide data for the InvalidPacketReceived event
    /// </summary>
    internal sealed class InvalidPacketReceivedEventArgs : System.EventArgs
    {
        public InvalidPacketReceivedEventArgs(byte[] packetBytes)
        {
            PacketBytes = packetBytes ?? throw new ArgumentNullException(nameof(packetBytes));
        }

        /// <summary>
        /// Gets invalid packet bytes
        /// </summary>
        public byte[] PacketBytes { get; }
    }
}