using System.Collections.Concurrent;

namespace Mavlink.Packets
{
    internal sealed class PacketBuilderDirector : IPacketBuilderDirector
    {
        private readonly ConcurrentBag<byte> _packetBuffer = new ConcurrentBag<byte>();
        private readonly MavlinkVersion _mavlinkVersion;
        private readonly PacketDefinition _packetDefinition;
        private readonly PacketStructure _packetStructure;

        public PacketBuilderDirector(MavlinkVersion mavlinkVersion, IPacketBlueprint packetBlueprint)
        {
            _mavlinkVersion = mavlinkVersion;
            PacketDefinition _packetDefinition = packetBlueprint.GetPacketDefinition(mavlinkVersion);
            PacketStructure _packetStructure = packetBlueprint.GetPacketStructrure(mavlinkVersion);
        }

        public bool AddByte(byte packetByte)
        {
            if (packetByte == _packetDefinition.Header)
                return false;

            _packetBuffer.Add(packetByte);
            return true;
        }

        public IPacketBuilder Construct()
        {
            throw new System.NotImplementedException();
        }
    }
}