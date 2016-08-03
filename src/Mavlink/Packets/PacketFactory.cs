// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating a packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets
{
    /// <summary>
    /// Factory which is responsible for creating a packet
    /// </summary>
    internal sealed class PacketFactory : IPacketFactory
    {
        private const int PayloadLengthIndex = 1;
        private const int PacketSequenceIndex = 2;
        private const int SystemIdIndex = 3;
        private const int ComponentIdIndex = 4;
        private const int MessageIdIndex = 5;
        private const int PayloadIndex = 6;
        private const int ChecksumLength = 2;

        /// <summary>
        /// Creates a mavlink packet based on bytes array
        /// </summary>
        /// <param name="bytes">Bytes array on which packet will be created</param>
        /// <returns>New mavlink packet</returns>
        public Packet Create(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            int payloadLength = Convert.ToInt32(bytes[PayloadLengthIndex]);
            byte[] payload = new byte[payloadLength];
            byte[] checksum = new byte[ChecksumLength];
            Array.Copy(bytes, PayloadLengthIndex, payload, 0, payloadLength);
            Array.Copy(bytes, PayloadIndex + PayloadLengthIndex, checksum, 0, ChecksumLength);

            return new Packet(bytes[PayloadLengthIndex], bytes[PacketSequenceIndex], bytes[SystemIdIndex],
                bytes[ComponentIdIndex], bytes[MessageIdIndex], payload, checksum);
        }
    }
}