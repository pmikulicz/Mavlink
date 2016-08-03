using System;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    internal sealed class PacketHandler : IPacketHandler
    {
        private readonly IPacketFactory _packetFactory;

        public PacketHandler(IPacketFactory packetFactory)
        {
            if (packetFactory == null)
                throw new ArgumentNullException(nameof(packetFactory));

            _packetFactory = packetFactory;
        }

        public PacketHandler()
            : this(new PacketFactory())
        {
        }

        public IEnumerable<Packet> HandlePackets(byte[] bytes)
        {
            return null;
        }
    }
}