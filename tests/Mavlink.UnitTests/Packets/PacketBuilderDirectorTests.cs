using Mavlink.Packets;
using Mavlink.Packets.V1;
using Moq;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    public class PacketBuilderDirectorTests
    {
        private static readonly Mock<IPacketBuilderFactory> PacketBuilderFactory = new Mock<IPacketBuilderFactory>();

        public PacketBuilderDirectorTests()
        {
            PacketBuilderFactory.Setup(factory => factory.Create(It.IsAny<byte[]>(), It.IsAny<PacketStructure>()))
                .Returns(It.IsAny<IPacketBuilder>());
        }

        public sealed class AddByteTests : PacketBuilderDirectorTests
        {
            [Fact]
            public void AddByte_HeaderByte_ReturnFalse()
            {
                var packetBuilderDirector = new PacketBuilderDirector(PacketBuilderFactory.Object, new PacketV1Structure());
                var expectedvalue = false;

                var nextByte = packetBuilderDirector.AddByte(Constants.HeartbeatPacketV1Bytes[0]);

                Assert.Equal(expectedvalue, nextByte);
            }

            [Fact]
            public void AddByte_SequenceByte_ReturnTrue()
            {
                var packetBuilderDirector = new PacketBuilderDirector(PacketBuilderFactory.Object, new PacketV1Structure());
                var expectedvalue = true;

                var nextByte = packetBuilderDirector.AddByte(Constants.HeartbeatPacketV1Bytes[2]);

                Assert.Equal(expectedvalue, nextByte);
            }
        }
    }
}