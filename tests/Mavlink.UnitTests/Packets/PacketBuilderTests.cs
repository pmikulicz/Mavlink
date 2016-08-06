using Mavlink.Messages.Types;
using Mavlink.Packets;
using Moq;
using NUnit.Framework;

namespace Mavlink.UnitTests.Packets
{
    [TestFixture]
    internal class PacketBuilderTests
    {
        protected IPacketBuilder PacketBuilder;

        protected readonly byte[] HeartbeatPacketBytes =
            {
                0xFE, 0x09, 0x4E, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x03,
                0x51, 0x04, 0x03, 0x1C, 0x7F
            };

        [SetUp]
        public void SetUp()
        {
            Mock<IPacketValidator> mockPacketValidator = new Mock<IPacketValidator>();
            mockPacketValidator
                .Setup(validator => validator.Validate(It.IsAny<Packet>()))
                .Returns(true);
            PacketBuilder = new PacketBuilder(mockPacketValidator.Object);
        }

        [TestFixture]
        public sealed class AddByteTests : PacketBuilderTests
        {
            [Test]
            public void AddByteReturnFalse()
            {
                bool result = PacketBuilder.AddByte(HeartbeatPacketBytes[0]);

                Assert.AreEqual(false, result);
            }

            [Test]
            public void AddByteReturnTrue()
            {
                for (int i = 0; i < HeartbeatPacketBytes.Length - 1; i++)
                {
                    bool completed = PacketBuilder.AddByte(HeartbeatPacketBytes[i]);
                }

                bool result = PacketBuilder.AddByte(HeartbeatPacketBytes[HeartbeatPacketBytes.Length - 1]);

                Assert.AreEqual(true, result);
            }
        }

        [TestFixture]
        public sealed class BuildTests : PacketBuilderTests
        {
            [Test]
            public void BuildReturnNull()
            {
                PacketBuilder.AddByte(HeartbeatPacketBytes[0]);

                Packet packet = PacketBuilder.Build();

                Assert.AreEqual(null, packet);
            }

            [Test]
            public void BuildReturnPacket()
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

                Assert.AreNotEqual(null, packet);
                Assert.AreEqual(expectedMessageId, packet.MessageId);
                Assert.AreEqual(expectedPayloadLegth, packet.PayloadLength);
                Assert.AreEqual(expectedSequenceNumber, packet.SequenceNumber);
                Assert.AreEqual(expectedSystemId, packet.SystemId);
                Assert.AreEqual(expectedHeader, packet.Header);
                Assert.AreEqual(expectedChecksum, packet.Checksum);
                Assert.AreEqual(expectedPayload, packet.Payload);
            }
        }
    }
}