// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketHandler.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for handling packets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which is responsible for handling packets
    /// </summary>
    internal interface IPacketHandler
    {
        /// <summary>
        /// Handles a packet based on passed bytes array
        /// </summary>
        /// <param name="bytes">Bytes array from which mavlink packets will be handled</param>
        /// <returns>Collection of mavlink packets</returns>
        IEnumerable<Packet> HandlePackets(byte[] bytes);
    }
}