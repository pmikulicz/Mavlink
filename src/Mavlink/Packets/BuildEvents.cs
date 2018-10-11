// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildEvents.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Model which represents build event which are triggered during packet building
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets
{
    /// <summary>
    ///  Model which represents build event which are triggered during packet building
    /// </summary>
    internal sealed class BuildEvents
    {
        public BuildEvents(Action<Packet> packetCreated, Action<byte[]> invalidPacketCreated)
        {
            PacketCreated = packetCreated ?? throw new ArgumentNullException(nameof(packetCreated));
            InvalidPacketCreated = invalidPacketCreated ?? throw new ArgumentNullException(nameof(invalidPacketCreated));
        }

        /// <summary>
        /// Gets action which is triggered on successfully created packet
        /// </summary>
        public Action<Packet> PacketCreated { get; }

        /// <summary>
        /// Gets action which is triggered on unsuccessfully created packet
        /// </summary>
        public Action<byte[]> InvalidPacketCreated { get; }
    }
}