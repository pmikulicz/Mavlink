﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Abstract model of packet internal structure
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Abstract model of packet internal structure
    /// </summary>
    internal abstract class PacketStructure
    {
        /// <summary>
        /// Gets header position in packet
        /// </summary>
        public int HeaderIndex { get; } = 0;

        /// <summary>
        /// Gets payload position in packet
        /// </summary>
        public int PayloadLenghtIndex { get; } = 1;

        /// <summary>
        /// Gets sequence number position in packet
        /// </summary>
        public abstract byte SequenceNumberIndex { get; }

        /// <summary>
        /// Gets system id position in packet
        /// </summary>
        public abstract byte SystemIdIndex { get; }

        /// <summary>
        /// Gets component id position in packet
        /// </summary>
        public abstract byte ComponentIdIndex { get; }

        /// <summary>
        /// Gets mavlink version of metadata
        /// </summary>
        public abstract MavlinkVersion MavlinkVersion { get; }
    }
}