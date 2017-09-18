// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketHandler.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for handling packets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
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

        /// <summary>
        /// Gets newly created packet
        /// </summary>
        /// <param name="systemId">System id</param>
        /// <param name="componentId">Component id</param>
        /// <param name="sequenceNumber">Number of a sequence</param>
        /// <param name="messageId">Message id</param>
        /// <param name="packetPayload">Message as a byte array</param>
        /// <returns></returns>
        Packet HandlePacket(byte systemId, byte componentId, byte sequenceNumber, int messageId, byte[] packetPayload);

        /// <summary>
        /// Occurs when an invalid packet has been received
        /// </summary>
        event EventHandler<InvalidPacketReceivedEventArgs> InvalidPacketReceived;
    }
}