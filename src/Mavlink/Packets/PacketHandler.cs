// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketHandler.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for handling packets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    ///  Component which is responsible for handling packets
    /// </summary>
    internal sealed class PacketHandler : IPacketHandler
    {
        private readonly IPacketBuilder _packetBuilder;

        public PacketHandler(IPacketBuilder packetBuilder)
        {
            if (packetBuilder == null)
                throw new ArgumentNullException(nameof(packetBuilder));

            _packetBuilder = packetBuilder;
        }

        public PacketHandler()
            : this(null)
        {
        }

        /// <summary>
        /// Handles a packet based on passed bytes array
        /// </summary>
        /// <param name="bytes">Bytes array from which mavlink packets will be handled</param>
        /// <returns>Collection of mavlink packets</returns>
        public IEnumerable<Packet> HandlePackets(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            foreach (var packetByte in bytes)
            {
                if (_packetBuilder.AddByte(packetByte))
                    yield return _packetBuilder.Build();
            }
        }
    }
}