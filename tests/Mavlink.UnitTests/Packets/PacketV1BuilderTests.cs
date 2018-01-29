using System.Collections.Generic;
using System.Reflection;
using Mavlink.Packets;
using Moq;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    public class PacketV1BuilderTests
    {
        private static readonly Mock<IPacketMetadataContext> PacketMetadataContextMoq = new Mock<IPacketMetadataContext>();
        private static readonly IPacketBuilder PacketBuilder;

        private static readonly Dictionary<PropertyInfo, int> Metadata = new Dictionary<PropertyInfo, int>
        {
            {typeof(PacketV1).GetProperty("Header"), 0},
            {typeof(PacketV1).GetProperty("PayloadLength"), 1},
            {typeof(PacketV1).GetProperty("SequenceNumber"), 2},
            {typeof(PacketV1).GetProperty("SystemId"), 3},
            {typeof(PacketV1).GetProperty("ComponentId"), 4},
            {typeof(PacketV1).GetProperty("ByteId"), 5}
        };

        static PacketV1BuilderTests()
        {
            PacketMetadataContextMoq.Setup(mc => mc.MetadataLength).Returns(Metadata.Count);

            foreach (var property in Metadata.Keys)
            {
                PacketMetadataContextMoq
                    .Setup(mc => mc.GetDataIndex(property)).Returns(Metadata[property]);
            }

            foreach (var property in Metadata.Keys)
            {
                PacketMetadataContextMoq
                    .Setup(mc => mc.HasDataIndex(property)).Returns(true);
            }

            PacketMetadataContextMoq.Setup(mc => mc.SignatureLength).Returns(0);
            PacketMetadataContextMoq.Setup(mc => mc.CrCLength).Returns(2);
            PacketMetadataContextMoq.Setup(mc => mc.MaxPayloadLength).Returns(255);

            PacketBuilder = new PacketV1Builder(PacketMetadataContextMoq.Object);
        }

        public sealed class AddByteTests : PacketV1BuilderTests
        {
            [Fact]
            public void AddByte_HeaderByte_ReturnTrue()
            {
                bool expectedValue = true;
                bool accualValue = PacketBuilder.AddByte(Constants.HeartbeatPacketBytes[0]);
                Assert.Equal(expectedValue, accualValue);
            }

            [Fact]
            public void AddByte_AddLastByte_ReturnFalse()
            {
                for (int i = 0; i < Constants.HeartbeatPacketBytes.Length - 1; i++)
                {
                    PacketBuilder.AddByte(Constants.HeartbeatPacketBytes[i]);
                }

                bool expectedValue = false;
                bool accualValue = PacketBuilder.AddByte(Constants.HeartbeatPacketBytes[Constants.HeartbeatPacketBytes.Length - 1]);
                Assert.Equal(expectedValue, accualValue);
            }
        }
    }
}