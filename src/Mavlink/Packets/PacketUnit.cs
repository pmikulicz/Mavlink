namespace Mavlink.Packets
{
    internal sealed class PacketUnit
    {
        public PacketUnit(bool firstByte, byte content)
        {
            FirstByte = firstByte;
            Content = content;
        }

        public bool FirstByte { get; }

        public byte Content { get; }
    }
}