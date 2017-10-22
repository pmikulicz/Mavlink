// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketValidator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsoble for validating packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which is responsoble for validating packet
    /// </summary>
    internal sealed class PacketValidator : IPacketValidator
    {
        private const int X25InitCrc = 0xFFFF;
        private const int X25ValidateCrc = 0xF0B8;

        /// <inheritdoc />
        public bool Validate(Packet packet)
        {
            if (packet == null)
                throw new ArgumentNullException(nameof(packet));

            int crc = GetPacketCrc(packet);

            return (byte)(crc & 0xFF) == packet.Checksum[0] &&
                   (byte)(crc >> 8) == packet.Checksum[1];
        }

        /// <inheritdoc />
        public byte[] GetChecksum(Packet packet)
        {
            int crc = GetPacketCrc(packet);

            return new[] { (byte)(crc & 0xFF), (byte)(crc >> 8) };
        }

        private static int GetPacketCrc(Packet packet)
        {
            return 0;
            //            int crc = X25InitCrc;
            //            crc = X25CrcAccumulate(packet.PayloadLength, crc);
            //            crc = X25CrcAccumulate(packet.SequenceNumber, crc);
            //            crc = X25CrcAccumulate(packet.SystemId, crc);
            //            crc = X25CrcAccumulate(packet.ComponentId, crc);
            //            crc = X25CrcAccumulate((byte)packet.MessageIdOld, crc);
            //            crc = packet.Payload.Aggregate(crc, (current, payloadByte) => X25CrcAccumulate(payloadByte, current));
            //
            //            return X25CrcAccumulate(GetCrcForMessageId((byte)packet.MessageIdOld), crc);
        }

        private static int X25CrcAccumulate(byte crcByte, int crc)
        {
            unchecked
            {
                byte b = (byte)(crcByte ^ (byte)(crc & 0x00FF));
                b = (byte)(b ^ (b << 4));
                return (crc >> 8) ^ (b << 8) ^ (b << 3) ^ (b >> 4);
            }
        }

        // TODO: change it !!
        private static byte GetCrcForMessageId(byte messageId)
        {
            switch (messageId)
            {
                case 0: return 50;
                case 1: return 124;
                case 2: return 137;
                case 4: return 237;
                case 5: return 217;
                case 6: return 104;
                case 7: return 119;
                case 11: return 89;
                case 20: return 214;
                case 21: return 159;
                case 22: return 220;
                case 23: return 168;
                case 24: return 24;
                case 25: return 23;
                case 26: return 170;
                case 27: return 144;
                case 28: return 67;
                case 29: return 115;
                case 30: return 39;
                case 31: return 246;
                case 32: return 185;
                case 33: return 104;
                case 34: return 237;
                case 35: return 244;
                case 36: return 222;
                case 37: return 212;
                case 38: return 9;
                case 39: return 254;
                case 40: return 230;
                case 41: return 28;
                case 42: return 28;
                case 43: return 132;
                case 44: return 221;
                case 45: return 232;
                case 46: return 11;
                case 47: return 153;
                case 48: return 41;
                case 49: return 39;
                case 50: return 214;
                case 51: return 223;
                case 52: return 141;
                case 53: return 33;
                case 54: return 15;
                case 55: return 3;
                case 56: return 100;
                case 57: return 24;
                case 58: return 239;
                case 59: return 238;
                case 60: return 30;
                case 61: return 240;
                case 62: return 183;
                case 63: return 130;
                case 64: return 130;
                case 66: return 148;
                case 67: return 21;
                case 69: return 243;
                case 70: return 124;
                case 74: return 20;
                case 76: return 152;
                case 77: return 143;
                case 80: return 127;
                case 81: return 106;
                case 89: return 231;
                case 90: return 183;
                case 91: return 63;
                case 92: return 54;
                case 100: return 175;
                case 101: return 102;
                case 102: return 158;
                case 103: return 208;
                case 104: return 56;
                case 105: return 93;
                case 106: return 211;
                case 107: return 108;
                case 108: return 32;
                case 109: return 185;
                case 110: return 235;
                case 111: return 93;
                case 112: return 124;
                case 113: return 124;
                case 114: return 119;
                case 115: return 4;
                case 147: return 177;
                case 148: return 241;
                case 149: return 15;
                case 249: return 204;
                case 250: return 49;
                case 251: return 170;
                case 252: return 44;
                case 253: return 83;
                case 254: return 86;
                case 150: return 134;
                case 151: return 219;
                case 152: return 208;
                case 153: return 188;
                case 154: return 84;
                case 155: return 22;
                case 156: return 19;
                case 157: return 21;
                case 158: return 134;
                case 160: return 78;
                case 161: return 68;
                case 162: return 189;
                case 163: return 127;
                case 164: return 154;
                case 165: return 21;
                case 166: return 21;
                case 167: return 144;
                case 168: return 1;
                case 169: return 234;
                case 170: return 73;
                case 171: return 181;
                case 172: return 22;
                case 173: return 83;
                case 174: return 167;
                case 175: return 138;
                case 176: return 234;
                default: return 0;
            }
        }
    }
}