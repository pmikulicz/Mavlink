using System.Collections.Concurrent;
using System.Linq;
using Mavlink.Packets.V1;

namespace Mavlink.Packets
{
    internal sealed class PacketBuilderDirector : IPacketBuilderDirector
    {
        private readonly MavlinkVersion _mavlinkVersion;
        private readonly PacketDefinition _packetDefinition;
        private readonly PacketStructure _packetStructure;
        private readonly ConcurrentBag<byte> _packetBuffer = new ConcurrentBag<byte>();

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

        public bool AddByte(byte packetByte)
        {
            if (packetByte == _packetDefinition.Header)
                return false;

            _packetBuffer.Add(packetByte);

            return true;
        }

        public IPacketBuilder Construct()
        {
            var packetBuilder = new PacketV1Builder(new[] { _packetDefinition.Header }.Concat(_packetBuffer).ToArray(),
                _packetStructure);
            _packetBuffer.Clear();

            return packetBuilder;
        }
    }
}