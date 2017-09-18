using System;
using System.Collections.Generic;
using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class MessageMetadataContainerTests
    {
        public sealed class GetTests : MessageMetadataContainerTests
        {
            private static IMessageMetadataContainer _messageMetadataContainer;

            [Fact]
            public void Get_CorrectType_ReturnMessageMetadata()
            {
                Type heartbeatMessageType = typeof(HeartbeatMessage);

                _messageMetadataContainer = new MessageMetadataContainer(new List<MessageMetadata>
                {
                    new MessageMetadata(heartbeatMessageType)
                });

                var messageMetadata = _messageMetadataContainer.Get(heartbeatMessageType);

                Assert.NotEqual(messageMetadata, null);
            }

            [Fact]
            public void Get_IncorrectType_ReturnNull()
            {
                Type heartbeatMessageType = typeof(HeartbeatMessage);

                _messageMetadataContainer = new MessageMetadataContainer(new List<MessageMetadata>
                {
                    new MessageMetadata(heartbeatMessageType)
                });

                var messageMetadata = _messageMetadataContainer.Get(typeof(MavlinkMessage));

                Assert.Equal(messageMetadata, null);
            }
        }
    }
}