using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using System.Collections.Generic;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class MessageMetadataContainerTests
    {
        public sealed class GetTests : MessageMetadataContainerTests
        {
            private static IMessageMetadataContainer _messageMetadataContainer;

            [Fact]
            public void Get_CorrectMessageId_ReturnMessageMetadata()
            {
                var heartbeatMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);

                _messageMetadataContainer = new MessageMetadataContainer(new List<MessageMetadata>
                {
                    Constants.HeartBeatMessageMetadata
                });

                var messageMetadata = _messageMetadataContainer.Get(heartbeatMessageId.Value);

                Assert.NotNull(messageMetadata);
            }

            [Fact]
            public void Get_IncorrectMessageId_ReturnNull()
            {
                ArdupilotMessageId incorrectMessageId = new ArdupilotMessageId((ArdupilotId)123456789);

                _messageMetadataContainer = new MessageMetadataContainer(new List<MessageMetadata>
                {
                    Constants.HeartBeatMessageMetadata
                });

                var messageMetadata = _messageMetadataContainer.Get(incorrectMessageId.Value);

                Assert.Null(messageMetadata);
            }
        }
    }
}