// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketHandler.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for handling packets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
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
            _packetBuilder = packetBuilder ?? throw new ArgumentNullException(nameof(packetBuilder));
        }

        /// <inheritdoc />
        public IEnumerable<Packet> HandlePackets(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            foreach (byte packetByte in bytes)
            {
                if (!_packetBuilder.AddByte(packetByte)) continue;

                Packet packet = _packetBuilder.Build();

                if (packet != null)
                    yield return packet;
                else
                    InvalidPacketReceived?.Invoke(this, new InvalidPacketReceivedEventArgs(bytes));
            }
        }

        public Packet HandlePacket(byte systemId, byte componentId, byte sequenceNumber, int messageId, byte[] packetPayload)
        {
            return null;
            //            PacketBuilder packetBuilder = new PacketBuilder();
            //            byte[] emptyChecksum = { 0x00, 0x00 };
            //
            //            if (packetBuilder.AddByte(Packet.HeaderValue))
            //                return null;
            //
            //            if (packetBuilder.AddByte((byte)packetPayload.Length))
            //                return null;
            //
            //            if (packetBuilder.AddByte(sequenceNumber))
            //                return null;
            //
            //            if (packetBuilder.AddByte(systemId))
            //                return null;
            //
            //            if (packetBuilder.AddByte(componentId))
            //                return null;
            //
            //            if (packetBuilder.AddByte((byte)messageIdOld))
            //                return null;
            //
            //            if (packetPayload.Any(payloadByte => packetBuilder.AddByte(payloadByte)))
            //                return null;
            //
            //            if (packetBuilder.AddByte(emptyChecksum[0]))
            //                return null;
            //
            //            return !packetBuilder.AddByte(emptyChecksum[1]) ?
            //                null :
            //                packetBuilder.Build(BuildType.WithoutCrc);
        }

        /// <inheritdoc />
        public Packet HandlePacket(byte systemId, byte componentId, byte sequenceNumber, MessageIdOld messageIdOld, byte[] packetPayload)
        {
            return null;
            //            PacketBuilder packetBuilder = new PacketBuilder();
            //            byte[] emptyChecksum = { 0x00, 0x00 };
            //
            //            if (packetBuilder.AddByte(Packet.HeaderValue))
            //                return null;
            //
            //            if (packetBuilder.AddByte((byte)packetPayload.Length))
            //                return null;
            //
            //            if (packetBuilder.AddByte(sequenceNumber))
            //                return null;
            //
            //            if (packetBuilder.AddByte(systemId))
            //                return null;
            //
            //            if (packetBuilder.AddByte(componentId))
            //                return null;
            //
            //            if (packetBuilder.AddByte((byte)messageIdOld))
            //                return null;
            //
            //            if (packetPayload.Any(payloadByte => packetBuilder.AddByte(payloadByte)))
            //                return null;
            //
            //            if (packetBuilder.AddByte(emptyChecksum[0]))
            //                return null;
            //
            //            return !packetBuilder.AddByte(emptyChecksum[1]) ?
            //                null :
            //                packetBuilder.Build(BuildType.WithoutCrc);
        }

        /// <inheritdoc />
        public event EventHandler<InvalidPacketReceivedEventArgs> InvalidPacketReceived;

        private void OnInvalidPacketReceived(InvalidPacketReceivedEventArgs e)
        {
            InvalidPacketReceived?.Invoke(this, e);
        }
    }
}