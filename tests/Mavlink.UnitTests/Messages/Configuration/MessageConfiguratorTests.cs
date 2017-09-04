using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using System;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class MessageConfiguratorTests
    {
        private static IMessageConfigurator _messageConfigurator = new MessageConfigurator(new MessageDetails(typeof(HeartbeatMessage)));

        public sealed class SetNameTests : MessageConfiguratorTests
        {
            [Fact]
            public void SetName_NullString_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _messageConfigurator.SetName(null));
            }

            [Fact]
            public void SetName_EmptyString_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _messageConfigurator.SetName(string.Empty));
            }

            [Fact]
            public void SetName_CorrectName_Ok()
            {
                var messageDetails = new MessageDetails(typeof(HeartbeatMessage));
                _messageConfigurator = new MessageConfigurator(messageDetails);
                var expectedMessageName = "HEARTBEAT";
                _messageConfigurator.SetName(expectedMessageName);

                Assert.Equal(expectedMessageName, messageDetails.Name);
            }
        }

        public sealed class SetIdTests : MessageConfiguratorTests
        {
            [Fact]
            public void SetId_CorrectId_Ok()
            {
                var messageDetails = new MessageDetails(typeof(HeartbeatMessage));
                _messageConfigurator = new MessageConfigurator(messageDetails);
                var expectedMessageId = 1;
                _messageConfigurator.SetId(expectedMessageId);

                Assert.Equal(expectedMessageId, messageDetails.Id);
            }
        }
    }
}