// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketReceivedEventArgs.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents event argument that is used to provide data for the PacketReceived event
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Packets;
using System;

namespace Mavlink.EventArgs
{
    /// <summary>
    /// Represents event argument that is used to provide data for the PacketReceived event
    /// </summary>
    internal sealed class PacketReceivedEventArgs : System.EventArgs
    {
        public PacketReceivedEventArgs(Packet packet)
        {
            Packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }

        /// <summary>
        /// Gets received packet
        /// </summary>
        public Packet Packet { get; }
    }
}