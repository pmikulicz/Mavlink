using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class MessageConfiguratorTests
    {
        private static IMessageMetadataConfigurator _messageMetadataConfigurator =
            new MessageMetadataMetadataConfigurator(
                new MessageMetadata(new Dictionary<PropertyInfo, PropertyMetadata>(), typeof(HeartbeatMessage)));

        public sealed class SetNameTests : MessageConfiguratorTests
        {
            [Fact]
            public void SetName_NullString_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _messageMetadataConfigurator.SetName(null));
            }

            [Fact]
            public void SetName_EmptyString_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _messageMetadataConfigurator.SetName(string.Empty));
            }

            [Fact]
            public void SetName_CorrectName_Ok()
            {
                var messageDetails = new MessageMetadata(new Dictionary<PropertyInfo, PropertyMetadata>(), typeof(HeartbeatMessage));
                _messageMetadataConfigurator = new MessageMetadataMetadataConfigurator(messageDetails);
                var expectedMessageName = "HEARTBEAT";
                _messageMetadataConfigurator.SetName(expectedMessageName);

                Assert.Equal(expectedMessageName, messageDetails.Name);
            }
        }

        public sealed class SetIdTests : MessageConfiguratorTests
        {
            [Fact]
            public void SetId_CorrectId_Ok()
            {
                var messageDetails = new MessageMetadata(new Dictionary<PropertyInfo, PropertyMetadata>(), typeof(HeartbeatMessage));
                _messageMetadataConfigurator = new MessageMetadataMetadataConfigurator(messageDetails);
                var expectedMessageId = 1;
                _messageMetadataConfigurator.SetId(expectedMessageId);

                Assert.Equal(expectedMessageId, messageDetails.Id);
            }
        }
    }
}