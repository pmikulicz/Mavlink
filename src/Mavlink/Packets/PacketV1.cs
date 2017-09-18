using System.Collections.Generic;
using Mavlink.Messages;

namespace Mavlink.Packets
{
    internal sealed class PacketV1 : Packet
    {
        internal const byte HeaderValue = 0xFE;
        internal const int PacketSequenceIndex = 2;
        internal const int SystemIdIndex = 3;
        internal const int ComponentIdIndex = 4;
        internal const int MessageIdIndex = 5;
        internal const int PayloadIndex = 6;
        internal const int ChecksumLength = 2;
        internal const int MetadataLength = 6;

        /// <summary>
        /// Gets start of frame transmission
        /// </summary>
        public override byte Header { get; } = HeaderValue;
        
        /// <summary>
        /// Gets or sets identification of the message.
        /// The id defines what the payload "means" and how it should be correctly decoded
        /// </summary>
        public byte MessageId { get; set; }
       

        /// <summary>
        /// Gets packet array of raw bytes
        /// </summary>
        public override byte[] RawBytes
        {
            get
            {
                var rawBytes = new List<byte>
                {
                    HeaderValue,
                    PayloadLength,
                    SequenceNumber,
                    SystemId,
                    ComponentId,
                    MessageId
                };
                rawBytes.AddRange(Payload);
                rawBytes.AddRange(Checksum);

                return rawBytes.ToArray();
            }
        }
    }
}