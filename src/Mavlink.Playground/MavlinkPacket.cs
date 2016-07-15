namespace Mavlink.Playground
{
    public class MavlinkPacket
    {
        public byte Header { get; set; }

        public byte PayloadLength { get; set; }

        public byte SequenceNumber { get; set; }

        public byte SystemId { get; set; }

        public byte ComponentId { get; set; }

        public byte MessageId { get; set; }

        public byte[] Payload { get; set; }

        public byte Checksum { get; set; }
    }
}