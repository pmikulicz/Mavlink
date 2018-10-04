// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketHandler.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for handling mavlink packets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    ///  Component which is responsible for handling mavlink packets
    /// </summary>
    internal sealed class PacketHandler : IPacketHandler
    {
        private readonly IPacketBuilder _packetBuilder;

        public PacketHandler(IPacketBuilder packetBuilder)
        {
            _packetBuilder = packetBuilder ?? throw new ArgumentNullException(nameof(packetBuilder));
        }

        /// <inheritdoc />
        public IEnumerable<Packet> HandlePackets(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            foreach (byte packetByte in bytes)
            {
                Packet packet = _packetBuilder.Build(null);

                if (packet != null)
                    yield return packet;
                else
                    InvalidPacketReceived?.Invoke(this, new InvalidPacketReceivedEventArgs(bytes));
            }
        }

        public Packet HandlePacket(byte systemId, byte componentId, byte sequenceNumber, int messageId, byte[] packetPayload)
        {
            return null;
            //            PacketV1Builder packetBuilder = new PacketV1Builder();
            //            byte[] emptyChecksum = { 0x00, 0x00 };
            //
            //            if (packetBuilder.CheckByte(Packet.HeaderValue))
            //                return null;
            //
            //            if (packetBuilder.CheckByte((byte)packetPayload.Length))
            //                return null;
            //
            //            if (packetBuilder.CheckByte(sequenceNumber))
            //                return null;
            //
            //            if (packetBuilder.CheckByte(systemId))
            //                return null;
            //
            //            if (packetBuilder.CheckByte(componentId))
            //                return null;
            //
            //            if (packetBuilder.CheckByte((byte)messageIdOld))
            //                return null;
            //
            //            if (packetPayload.Any(payloadByte => packetBuilder.CheckByte(payloadByte)))
            //                return null;
            //
            //            if (packetBuilder.CheckByte(emptyChecksum[0]))
            //                return null;
            //
            //            return !packetBuilder.CheckByte(emptyChecksum[1]) ?
            //                null :
            //                packetBuilder.Build(BuildType.WithoutCrc);
        }

        /// <inheritdoc />
        public event EventHandler<InvalidPacketReceivedEventArgs> InvalidPacketReceived;
    }
}