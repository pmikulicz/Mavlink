using Mavlink.Packets.V1;

namespace Mavlink.Packets
{
    internal sealed class PacketBuilderDirector : IPacketBuilderDirector
    {
        private readonly MavlinkVersion _mavlinkVersion;
        private readonly PacketDefinition _packetDefinition;
        private readonly PacketStructure _packetStructure;

        public PacketBuilderDirector(MavlinkVersion mavlinkVersion, IPacketBlueprint packetBlueprint)
        {
            _mavlinkVersion = mavlinkVersion;
            _packetDefinition = packetBlueprint.GetPacketDefinition(mavlinkVersion);
            _packetStructure = packetBlueprint.GetPacketStructrure(mavlinkVersion);
        }

        public PacketBuilderDirector(MavlinkVersion mavlinkVersion)
            : this(mavlinkVersion, new PacketBlueprint())
        {
        }

        public PacketUnit CheckByte(byte packetByte)
        {
            return packetByte == _packetDefinition.Header
                ? new PacketUnit(true, packetByte)
                : new PacketUnit(false, packetByte);
        }

        public IPacketBuilder Construct()
        {
            return new PacketV1Builder(_packetStructure);
        }
    }
}