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

                Assert.NotEqual(messageMetadataContainer.Quantity, 0);
            }

            [Fact]
            public void Provide_ReturnEmptyCollection()
            {
                var messageMetadataContainer = MessageMetadataContainerFactory.Create<MavlinkMessage>();

                Assert.Equal(messageMetadataContainer.Quantity, 0);
            }
        }
    }
}