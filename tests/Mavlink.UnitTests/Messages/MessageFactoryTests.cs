using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Mavlink.Messages.Implementations.Common.Types;
using Moq;
using System;
using Xunit;

namespace Mavlink.UnitTests.Messages
{
    public class MessageFactoryTests
    {
        private static IMessageFactory<ArdupilotMessage> _messageFactory;
        private static readonly Mock<IMessageMetadataContainerFactory> ContainerFactoryMock = new Mock<IMessageMetadataContainerFactory>();

        public MessageFactoryTests()
        {
            ContainerFactoryMock.Setup(config => config.Create<ArdupilotMessage>()).Returns(new MessageMetadataContainer(
                new[]
                {
                    Constants.HeartBeatMessageMetadata
                }));
            _messageFactory = new MessageFactory<ArdupilotMessage>(ContainerFactoryMock.Object, null);
        }

        protected readonly byte[] HeartbeatMessagePayload =
        {
            0x0, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03
        };

        protected readonly byte[] MissionRequestPartialListPayload =
        {
            0x0, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03
        };

        protected readonly byte[] ChangeOperatorControlMessagePayload =
        {
            0x01, 0x00, 0x00,
            0x74, 0x74, 0x74, 0x65, 0x65, 0x65, 0x73, 0x73, 0x73, 0x74, 0x74, 0x74, 0x74, 0x74, 0x74, 0x65, 0x65, 0x65, 0x73, 0x73, 0x73, 0x74, 0x74, 0x74, 0x31
        };

        protected readonly byte[] GpsStatusMessagePayload =
        {
            // SatellitesVisible
            0x01,
            // SatellitePrn
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            // SatelliteUsed
            0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03,
            // SatelliteElevation
            0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04,
            // SatelliteAzimuth
            0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
            // SatelliteSnr
            0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06
        };

        protected MessageIdOld HeartbeatMessageIdOld = MessageIdOld.Heartbeat;
        protected MessageIdOld ChangeOperatorControlMessageIdOld = MessageIdOld.ChangeOperatorControl;
        protected MessageIdOld GpsStatusMessageIdOld = MessageIdOld.GpsStatus;

        public sealed class CreateMethodTests : MessageFactoryTests
        {
            [Fact]
            public void CreateMessage_NullMessage_ThrowArgumentNullException()
            {
                int messageId = Constants.HeartbeatMessageId;
                Assert.Throws<ArgumentNullException>(() => _messageFactory.CreateMessage(null, messageId));
            }

            [Fact]
            public void CreateMessage_Ok()
            {
                int messageId = Constants.HeartbeatMessageId;
                _messageFactory.CreateMessage(Constants.HeartbeatMessagePayload, messageId);
            }

            [Fact]
            public void CreateThrowInvalidOperationExceptionWhenEnumNotDefined()
            {
                //                Assert.Throws<InvalidOperationException>(() => MessageFactory.CreateMessage(new byte[] { }, (MessageIdOld)254));
            }

            [Fact]
            public void CreateReturnsMessage()
            {
                var expectedType = MavType.Quadrotor;
                var expectedAutopilot = MavAutopilot.Ardupilotmega;
                var expectedBaseMode = MavModeFlag.CustomModeEnabled | MavModeFlag.StabilizeEnabled | MavModeFlag.ManualInputEnabled;
                uint expectedCustomMode = 0;
                var expectedSystemStatus = MavState.Active;
                byte expectedMavlinkVersion = 3;

                //                HeartbeatMessage message = (HeartbeatMessage)MessageFactory.CreateMessage(HeartbeatMessagePayload, HeartbeatMessageIdOld);

                //                Assert.NotNull(message);
                //                Assert.Equal(expectedAutopilot, message.Autopilot);
                //                Assert.Equal(expectedType, message.Type);
                //                Assert.Equal(expectedCustomMode, message.CustomMode);
                //                Assert.Equal(expectedBaseMode, message.BaseMode);
                //                Assert.Equal(expectedSystemStatus, message.SystemStatus);
                //                Assert.Equal(expectedMavlinkVersion, message.MavlinkVersion);
            }

            [Fact]
            public void CreateReturnsMessageWithFixedArray()
            {
                byte expectedTargetSystem = 0x01;
                byte expectedControlRequest = 0x00;
                byte expectedVersion = 0x00;
                char[] expectedPasskey =
                {
                    't', 't', 't', 'e', 'e', 'e', 's', 's', 's', 't', 't', 't', 't', 't', 't', 'e',
                    'e', 'e', 's', 's', 's', 't', 't', 't', '1'
                };

                //                ChangeOperatorControlMessage message = (ChangeOperatorControlMessage)MessageFactory.CreateMessage(ChangeOperatorControlMessagePayload, ChangeOperatorControlMessageIdOld);
                //
                //                Assert.NotNull(message);
                //                Assert.Equal(expectedTargetSystem, message.TargetSystem);
                //                Assert.Equal(expectedControlRequest, message.ControlRequest);
                //                Assert.Equal(expectedVersion, message.Version);
                //                Assert.Equal(expectedPasskey, message.Passkey);
            }

            [Fact]
            public void CreateReturnsMessageWithMultipleFixedArray()
            {
                byte satellitesVisible = 0x01;
                byte[] satellitePrn =
                {
                    0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
                    0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02
                };
                byte[] satelliteUsed =
                {
                    0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03,
                    0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03
                };

                byte[] satelliteElevation =
                {
                    0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04,
                    0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04
                };
                byte[] satelliteAzimuth =
                {
                    0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05,
                    0x05, 0x05, 0x05, 0x05, 0x05, 0x05, 0x05
                };

                byte[] satelliteSnr =
                {
                    0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06,
                    0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06
                };

                //                GpsStatusMessage message = (GpsStatusMessage)MessageFactory.CreateMessage(GpsStatusMessagePayload, GpsStatusMessageIdOld);
                //
                //                Assert.NotNull(message);
                //                Assert.Equal(satellitesVisible, message.SatellitesVisible);
                //                Assert.Equal(satellitePrn, message.SatellitePrn);
                //                Assert.Equal(satelliteUsed, message.SatelliteUsed);
                //                Assert.Equal(satelliteElevation, message.SatelliteElevation);
                //                Assert.Equal(satelliteAzimuth, message.SatelliteAzimuth);
                //                Assert.Equal(satelliteSnr, message.SatelliteSnr);
            }
        }
    }
}