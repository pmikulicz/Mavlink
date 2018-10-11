using Mavlink.Packets;
using Mavlink.Packets.V1;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    public class PacketV1BuilderTests
    {
        public sealed class BuildTests : PacketV1BuilderTests
        {
            [Fact]
            public void Build_CorrectBytes_TriggerPacketCreated()
            {
                bool expectedValue = true;
                var packetBuilder = new PacketV1Builder(Constants.HeartbeatPacketV1Bytes, new PacketV1Structure());
                bool packetCreatedTriggered = false;

                packetBuilder.Build(new BuildEvents(p =>
                {
                    packetCreatedTriggered = true;
                }, bytes =>
                {
                }));

                Assert.Equal(expectedValue, packetCreatedTriggered);
            }

            [Fact]
            public void Build_CorrectBytes_PacketCreatedReturnHeartbeatPacket()
            {
                var packetBuilder = new PacketV1Builder(Constants.HeartbeatPacketV1Bytes, new PacketV1Structure());
                Packet packet = null;
                packetBuilder.Build(new BuildEvents(p =>
                {
                    packet = p;
                }, bytes =>
                {
                }));

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
            public void Build_EmptyBytes_TriggerInvalidPacketCreated()
            {
                bool expectedValue = true;
                var packetBuilder = new PacketV1Builder(new byte[] { }, new PacketV1Structure());
                bool invalidPacketCreatedTriggered = false;

                packetBuilder.Build(new BuildEvents(p =>
                {
                }, bytes =>
                {
                    invalidPacketCreatedTriggered = true;
                }));

                Assert.Equal(expectedValue, invalidPacketCreatedTriggered);
            }

            [Fact]
            public void Build_EmptyBytes_InvalidPacketCreatedReturnEmptyBytes()
            {
                byte[] expectedBytes = { };
                byte[] packetBytes = null;
                var packetBuilder = new PacketV1Builder(expectedBytes, new PacketV1Structure());

                packetBuilder.Build(new BuildEvents(p =>
                {
                }, bytes =>
                {
                    packetBytes = bytes;
                }));

                Assert.Equal(expectedBytes, packetBytes);
            }

            [Fact]
            public void Build_NotEnoughtBytesToReadPayloadLength_TriggerInvalidPacketCreated()
            {
                bool expectedValue = true;
                var packetBuilder = new PacketV1Builder(new byte[] { 0x0 }, new PacketV1Structure());
                bool invalidPacketCreatedTriggered = false;

                packetBuilder.Build(new BuildEvents(p =>
                {
                }, bytes =>
                {
                    invalidPacketCreatedTriggered = true;
                }));

                Assert.Equal(expectedValue, invalidPacketCreatedTriggered);
            }

            [Fact]
            public void Build_WrongPacketBytesSize_TriggerInvalidPacketCreated()
            {
                bool expectedValue = true;
                var packetBuilder = new PacketV1Builder(new byte[] { 0x0, 0x0, 0x0, 0x0 }, new PacketV1Structure());
                bool invalidPacketCreatedTriggered = false;

                packetBuilder.Build(new BuildEvents(p =>
                {
                }, bytes =>
                {
                    invalidPacketCreatedTriggered = true;
                }));

                Assert.Equal(expectedValue, invalidPacketCreatedTriggered);
            }
        }
    }
}