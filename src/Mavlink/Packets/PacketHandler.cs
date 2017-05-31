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
using System.Linq;

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
            : this(new PacketBuilder())
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

        /// <summary>
        /// Gets newly created packet
        /// </summary>
        /// <param name="systemId">System id</param>
        /// <param name="componentId">Component id</param>
        /// <param name="sequenceNumber">Number of a sequence</param>
        /// <param name="messageId">Message id</param>
        /// <param name="packetPayload">Message as a byte array</param>
        /// <returns></returns>
        public Packet GetPacket(byte systemId, byte componentId, byte sequenceNumber, MessageId messageId, byte[] packetPayload)
        {
            PacketBuilder packetBuilder = new PacketBuilder();
            byte[] emptyChecksum = { 0x00, 0x00 };

            if (packetBuilder.AddByte(Packet.HeaderValue))
                return null;

            if (packetBuilder.AddByte((byte)packetPayload.Length))
                return null;

            if (packetBuilder.AddByte(sequenceNumber))
                return null;

            if (packetBuilder.AddByte(systemId))
                return null;

            if (packetBuilder.AddByte(componentId))
                return null;

            if (packetBuilder.AddByte((byte)messageId))
                return null;

            if (packetPayload.Any(payloadByte => packetBuilder.AddByte(payloadByte)))
                return null;

            if (packetBuilder.AddByte(emptyChecksum[0]))
                return null;

            return !packetBuilder.AddByte(emptyChecksum[1]) ?
                null :
                packetBuilder.Build(BuildType.WithoutCrc);
        }

        public event EventHandler<InvalidPacketReceivedEventArgs> InvalidPacketReceived;

        private void OnInvalidPacketReceived(InvalidPacketReceivedEventArgs e)
        {
            InvalidPacketReceived?.Invoke(this, e);
        }
    }
}