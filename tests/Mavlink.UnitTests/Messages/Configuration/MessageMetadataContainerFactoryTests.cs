using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class MessageMetadataContainerFactoryTests
    {
        private static readonly IMessageMetadataContainerFactory MessageMetadataContainerFactory = new MessageMetadataContainerFactory();

        public sealed class ProvideTests : MessageMetadataContainerFactoryTests
        {
            [Fact]
            public void Provide_ReturnNotEmptyCollection()
            {
                var messageMetadataContainer = MessageMetadataContainerFactory.Create<ArdupilotMessage>();

                const int expectedQuantity = 0;
                Assert.NotEqual(expectedQuantity, messageMetadataContainer.Quantity);
            }

            [Fact]
            public void Provide_ReturnEmptyCollection()
            {
                var messageMetadataContainer = MessageMetadataContainerFactory.Create<MavlinkMessage>();
                const int expectedQuantity = 0;

                Assert.Equal(expectedQuantity, messageMetadataContainer.Quantity);
            }
        }
    }
}