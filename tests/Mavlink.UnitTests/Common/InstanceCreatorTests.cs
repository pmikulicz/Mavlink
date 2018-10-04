using Mavlink.Common;
using Mavlink.Packets;
using Mavlink.Packets.V1;
using System.Collections.Generic;
using Xunit;

namespace Mavlink.UnitTests.Common
{
    public class InstanceCreatorTests
    {
        private static readonly IInstanceCreator InstanceCreator = new InstanceCreator();

        public sealed class CreateTests : InstanceCreatorTests
        {
            [Fact]
            public void Create_SimpleType_ReturnCorrectInstaceType()
            {
                var expectedType = typeof(int);
                var simpleInstance = InstanceCreator.Create<int>();

                Assert.Equal(expectedType, simpleInstance.GetType());
            }

            [Fact]
            public void Create_SimpleType_ReturnNewInstace()
            {
                var defaultSimpleValue = default(int);
                var simpleInstance = InstanceCreator.Create<int>();

                Assert.Equal(defaultSimpleValue, simpleInstance);
            }

            [Fact]
            public void Create_ComplexType_ReturnCorrectInstaceType()
            {
                var expectedType = typeof(PacketV1);
                var complexInstance = InstanceCreator.Create<PacketV1>();

                Assert.Equal(expectedType, complexInstance.GetType());
            }

            [Fact]
            public void Create_ComplexType_ReturnNewInstace()
            {
                var complexInstance = InstanceCreator.Create<PacketV1>();

                Assert.NotNull(complexInstance);
            }
        }

        public sealed class CreateDerivedTests : InstanceCreatorTests
        {
            [Fact]
            public void CreateDerived_ComplexType_ReturnCorrectTypes()
            {
                IEnumerable<PacketStructure> complexInstances = InstanceCreator.CreateDerived<PacketStructure>();

                foreach (var instance in complexInstances)
                {
                    Assert.IsAssignableFrom<PacketStructure>(instance);
                }
            }

            [Fact]
            public void Create_ComplexType_ReturnNewInstace()
            {
                IEnumerable<PacketStructure> complexInstances = InstanceCreator.CreateDerived<PacketStructure>();

                Assert.NotEmpty(complexInstances);
            }
        }
    }
}