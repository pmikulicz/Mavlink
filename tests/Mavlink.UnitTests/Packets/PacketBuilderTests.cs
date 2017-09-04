using Mavlink.Messages;
using Mavlink.Packets;
using Moq;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    internal class PacketBuilderTests
    {
        protected IPacketBuilder PacketBuilder;

        protected readonly byte[] HeartbeatPacketBytes =
            {
                0xFE, 0x09, 0x4E, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x03,
                0x51, 0x04, 0x03, 0x1C, 0x7F
            };

        public void SetUp()
        {
            Mock<IPacketValidator> mockPacketValidator = new Mock<IPacketValidator>();
            mockPacketValidator
                .Setup(validator => validator.Validate(It.IsAny<Packet>()))
                .Returns(true);
            mockPacketValidator
               .Setup(validator => validator.GetChecksum(It.IsAny<Packet>()))
               .Returns(new byte[] { 0x1C, 0x7F });
            PacketBuilder = new PacketBuilder(mockPacketValidator.Object);
        }

        public sealed class AddByteMethodTests : PacketBuilderTests
        {
            public void AddByteReturnsFalse()
            {
                bool result = PacketBuilder.AddByte(HeartbeatPacketBytes[0]);

                Assert.Equal(false, result);
            }

            [Fact]
            public void AddByteReturnsTrue()
            {
                for (int i = 0; i < HeartbeatPacketBytes.Length - 1; i++)
                {
                    bool completed = PacketBuilder.AddByte(HeartbeatPacketBytes[i]);
                }

                bool result = PacketBuilder.AddByte(HeartbeatPacketBytes[HeartbeatPacketBytes.Length - 1]);

                Assert.Equal(true, result);
            }
        }

        public sealed class BuildMethodTests : PacketBuilderTests
        {
            [Fact]
            public void BuildWithCrcReturnNull()
            {
                PacketBuilder.AddByte(HeartbeatPacketBytes[0]);

                Packet packet = PacketBuilder.Build();

                Assert.Equal(null, packet);
            }

            [Fact]
            public void BuildWithCrcReturnPacket()
            {
                foreach (byte packetByte in HeartbeatPacketBytes)
                    PacketBuilder.AddByte(packetByte);

                MessageId expectedMessageId = MessageId.Heartbeat;
                byte expectedPayloadLegth = 9;
                byte expectedSequenceNumber = 78;
                byte expectedSystemId = 1;
                byte expectedHeader = Packet.HeaderValue;
                byte[] expectedChecksum = { 0x1C, 0x7F };
                byte[] expectedPayload = { 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 };

                Packet packet = PacketBuilder.Build();

                Assert.NotNull(packet);
                Assert.Equal(expectedMessageId, packet.MessageId);
                Assert.Equal(expectedPayloadLegth, packet.PayloadLength);
                Assert.Equal(expectedSequenceNumber, packet.SequenceNumber);
                Assert.Equal(expectedSystemId, packet.SystemId);
                Assert.Equal(expectedHeader, packet.Header);
                Assert.Equal(expectedChecksum, packet.Checksum);
                Assert.Equal(expectedPayload, packet.Payload);
            }

            [Fact]
            public void BuildWithoutCrcReturnNull()
            {
                PacketBuilder.AddByte(HeartbeatPacketBytes[0]);

                Packet packet = PacketBuilder.Build();

                Assert.Equal(null, packet);
            }

            [Fact]
            public void BuildWithoutCrcReturnPacket()
            {
                for (int index = 0; index < HeartbeatPacketBytes.Length - 2; index++)
                {
                    byte packetByte = HeartbeatPacketBytes[index];
                    PacketBuilder.AddByte(packetByte);
                }

                // Checksum
                PacketBuilder.AddByte(0x00);
                PacketBuilder.AddByte(0x00);

                MessageId expectedMessageId = MessageId.Heartbeat;
                byte expectedPayloadLegth = 9;
                byte expectedSequenceNumber = 78;
                byte expectedSystemId = 1;
                byte expectedHeader = Packet.HeaderValue;
                byte[] expectedChecksum = { 0x1C, 0x7F };
                byte[] expectedPayload = { 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 };

                Packet packet = PacketBuilder.Build(BuildType.WithoutCrc);

                Assert.NotNull(packet);
                Assert.Equal(expectedMessageId, packet.MessageId);
                Assert.Equal(expectedPayloadLegth, packet.PayloadLength);
                Assert.Equal(expectedSequenceNumber, packet.SequenceNumber);
                Assert.Equal(expectedSystemId, packet.SystemId);
                Assert.Equal(expectedHeader, packet.Header);
                Assert.Equal(expectedChecksum, packet.Checksum);
                Assert.Equal(expectedPayload, packet.Payload);
            }
        }
    }
}