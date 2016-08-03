using System.Collections.Generic;

namespace Mavlink.Packets
{
    internal interface IPacketHandler
    {
        IEnumerable<Packet> HandlePackets(byte[] bytes);
    }
}