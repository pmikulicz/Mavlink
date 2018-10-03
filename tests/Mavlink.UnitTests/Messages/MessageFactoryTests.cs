using Mavlink.Common.Converters;
using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Mavlink.Messages.Implementations.Common.Types;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Mavlink.UnitTests.Messages
{
    public class MessageFactoryTests
    {
        private static IMessageProcessor<IArdupilotMessage> _messageProcessor;
        private static readonly Mock<IMessageMetadataContainerFactory> ContainerFactoryMock = new Mock<IMessageMetadataContainerFactory>();

        public MessageFactoryTests()
        {
            ContainerFactoryMock.Setup(config => config.Create<IArdupilotMessage>()).Returns(new MessageMetadataContainer(
                new[]
                {
                    Constants.HeartBeatMessageMetadata
                }));

            _messageProcessor = new MessageProcessor<IArdupilotMessage>(ContainerFactoryMock.Object, type =>
             {
                 var assembly = Assembly.GetAssembly(typeof(IConverter));
                 List<Type> converterTypes = assembly.GetTypes()
                     .Where(t =>
                     !t.IsAbstract &&
                     !t.IsInterface &&
                     t.IsClass &&
                     typeof(IConverter).IsAssignableFrom(t))
                     .ToList();

                 var converters = new List<IConverter>(converterTypes.Count);
                 converters.AddRange(converterTypes.Select(convertType => (IConverter)Activator.CreateInstance(convertType)));

                 return converters.FirstOrDefault(c => c.Type == type);
             });
        }

        public sealed class CreateMessageTests : MessageFactoryTests
        {
            [Fact]
            public void CreateMessage_NullMessagePayload_ThrowArgumentNullException()
            {
                int messageId = Constants.HeartbeatMessageId;
                Assert.Throws<ArgumentNullException>(() => _messageProcessor.CreateMessage(null, messageId));
            }

            [Fact]
            public void CreateMessage_TooManyPayloadBytes_ThrowInvalidOperationException()
            {
                int messageId = Constants.HeartbeatMessageId;
                Assert.Throws<InvalidOperationException>(() => _messageProcessor.CreateMessage(Utils.CreateByteArray(0, 20), messageId));
            }

            [Fact]
            public void CreateMessage_HeartbeatMessagePayload_ReturnMessageWithCorrectId()
            {
                int messageId = Constants.HeartbeatMessageId;
                IArdupilotMessage message = _messageProcessor.CreateMessage(Constants.HeartbeatMessagePayload, messageId);
                Assert.Equal(messageId, message.Id.Value);
            }

            [Fact]
            public void CreateMessage_HeartbeatMessagePayload_ReturnCorrectMessage()
            {
                int messageId = Constants.HeartbeatMessageId;
                HeartbeatMessage message = (HeartbeatMessage)_messageProcessor.CreateMessage(Constants.HeartbeatMessagePayload, messageId);
                MavType expectedType = Constants.HeartbeatMessage.Type;
                MavAutopilot expectedAutopilot = Constants.HeartbeatMessage.Autopilot;
                MavModeFlag expectedBaseMode = Constants.HeartbeatMessage.BaseMode;
                uint expectedCustomMode = Constants.HeartbeatMessage.CustomMode;
                MavState expectedSystemStatus = Constants.HeartbeatMessage.SystemStatus;
                byte expectedMavlinkVersion = Constants.HeartbeatMessage.MavlinkVersion;
                Assert.NotNull(message);
                Assert.Equal(expectedAutopilot, message.Autopilot);
                Assert.Equal(expectedType, message.Type);
                Assert.Equal(expectedCustomMode, message.CustomMode);
                Assert.Equal(expectedBaseMode, message.BaseMode);
                Assert.Equal(expectedSystemStatus, message.SystemStatus);
                Assert.Equal(expectedMavlinkVersion, message.MavlinkVersion);
            }
        }

        public sealed class CreateBytesTests : MessageFactoryTests
        {
            [Fact]
            public void CreateBytes_NullMessage_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _messageProcessor.CreateBytes(null));
            }

            [Fact]
            public void CreateBytes_HeartbeatMessage_ReturnCorrectBytes()
            {
                var messageBytes = _messageProcessor.CreateBytes(Constants.HeartbeatMessage);
                Assert.Equal(Constants.HeartbeatMessagePayload, messageBytes);
            }
        }
    }
}