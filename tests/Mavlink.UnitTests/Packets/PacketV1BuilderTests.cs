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

                Assert.Equal(Constants.HeartbeatPacketV1.MessageId, packet.MessageId);
                Assert.Equal(Constants.HeartbeatPacketV1.Header, packet.Header);
                Assert.Equal(Constants.HeartbeatPacketV1.ComponentId, packet.ComponentId);
                Assert.Equal(Constants.HeartbeatPacketV1.PayloadLength, packet.PayloadLength);
                Assert.Equal(Constants.HeartbeatPacketV1.SequenceNumber, packet.SequenceNumber);
                Assert.Equal(Constants.HeartbeatPacketV1.SystemId, packet.SystemId);
                Assert.Equal(Constants.HeartbeatPacketV1.Checksum, packet.Checksum);
                Assert.Equal(Constants.HeartbeatPacketV1.Payload, packet.Payload);
                Assert.Equal(Constants.HeartbeatPacketV1.RawBytes, packet.RawBytes);
            }

            [Fact]
            public void Build_EmptyBytes_ThrowMavlinkException()
            {
                var packetBuilder = new PacketV1Builder(new byte[] { }, new PacketV1Structure());

                Assert.Throws<MavlinkException>(() => packetBuilder.Build());
            }

            [Fact]
            public void Build_NotEnoughtBytesToReadPayloadLength_ThrowMavlinkException()
            {
                var packetBuilder = new PacketV1Builder(new byte[] { 0x0 }, new PacketV1Structure());

                Assert.Throws<MavlinkException>(() => packetBuilder.Build());
            }

            [Fact]
            public void Build_WrongPacketBytesSize_ReturnNull()
            {
                var packetBuilder = new PacketV1Builder(new byte[] { 0x0, 0x0, 0x0, 0x0 }, new PacketV1Structure());
                var packet = packetBuilder.Build();

                Assert.Null(packet);
            }
        }
    }
}