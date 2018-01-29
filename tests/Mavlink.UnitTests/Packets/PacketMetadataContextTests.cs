using System;
using Mavlink.Packets;
using Mavlink.Packets.Attributes;
using Xunit;

namespace Mavlink.UnitTests.Packets
{
    public class PacketMetadataContextTests
    {
        private static readonly IPacketMetadataContext PacketMetadataContext = new PacketMetadataContext(MavlinkVersion.V10);

        public sealed class GetDataIndexTests : PacketMetadataContextTests
        {
            [Fact]
            public void GetDataIndex_NullPropertyInfo_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => PacketMetadataContext.GetDataIndex(null));
            }

            [Fact]
            public void GetDataIndex_CorrectPropertyInfo_ReturnCorrectIndex()
            {
                const string propertyName = "SequenceNumber";
                int expectedValue = 2;
                var indexValue = PacketMetadataContext.GetDataIndex(typeof(PacketV1).GetProperty(propertyName));
                Assert.Equal(expectedValue, indexValue);
            }

            [Fact]
            public void GetDataIndex_CorrectBasePropertyInfo_ReturnCorrectIndex()
            {
                const string propertyName = "SequenceNumber";
                int expectedValue = 2;
                var indexValue = PacketMetadataContext.GetDataIndex(typeof(Packet).GetProperty(propertyName));
                Assert.Equal(expectedValue, indexValue);
            }

            [Fact]
            public void GetDataIndex_CorrectPropertyInfo_ReturnIncorrectIndex()
            {
                const string propertyName = "Header";
                int expectedValue = 4;
                var indexValue = PacketMetadataContext.GetDataIndex(typeof(PacketV1).GetProperty(propertyName));
                Assert.NotEqual(expectedValue, indexValue);
            }

            [Fact]
            public void GetDataIndex_CorrectBasePropertyInfo_ReturnIncorrectIndex()
            {
                const string propertyName = "Header";
                int expectedValue = 4;
                var indexValue = PacketMetadataContext.GetDataIndex(typeof(Packet).GetProperty(propertyName));
                Assert.NotEqual(expectedValue, indexValue);
            }

            [Fact]
            public void GetDataIndex_IncorrectPropertyInfo_ThrowInvalidOperationException()
            {
                const string propertyName = "TestProperty";
                Assert.Throws<InvalidOperationException>(() =>
                    PacketMetadataContext.GetDataIndex(typeof(TestPacket).GetProperty(propertyName)));
            }
        }

        public sealed class HasDataIndex : PacketMetadataContextTests
        {
            [Fact]
            public void HasDataIndex_NullPropertyInfo_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => PacketMetadataContext.GetDataIndex(null));
            }

            [Fact]
            public void HasDataIndex_CorrectPropertyInfo_ReturnTrue()
            {
                const string propertyName = "SequenceNumber";
                bool expectedValue = true;
                var indexValue = PacketMetadataContext.HasDataIndex(typeof(PacketV1).GetProperty(propertyName));
                Assert.Equal(expectedValue, indexValue);
            }

            [Fact]
            public void HasDataIndex_CorrectBasePropertyInfo_ReturnTrue()
            {
                const string propertyName = "SequenceNumber";
                bool expectedValue = true;
                var indexValue = PacketMetadataContext.HasDataIndex(typeof(Packet).GetProperty(propertyName));
                Assert.Equal(expectedValue, indexValue);
            }
        }

        internal sealed class TestPacket : Packet
        {
            public override byte Header { get; protected set; } = 0;

            public override int MessageId => 0;

            [PacketData(Index = 2, MavlinkVersion = (MavlinkVersion)3)]
            public int TestProperty { get; set; }

            protected override byte[] GetBytes()
            {
                return new[] { (byte)0 };
            }
        }
    }
}