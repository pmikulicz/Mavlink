using Mavlink.Packets.V1;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    public class PacketV1BuilderTests
    {
        public sealed class BuildTests : PacketV1BuilderTests
        {
            [Fact]
            public void Build_CorrectBytes_RetrunHearbeatPacket()
            {
                var packetBuilder = new PacketV1Builder(Constants.HeartbeatPacketV1Bytes, new PacketV1Structure());
                var packet = packetBuilder.Build();
            }
        }
    }
}