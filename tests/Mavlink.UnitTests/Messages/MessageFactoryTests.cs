using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common;
using Mavlink.Messages.Implementations.Common.Types;
using System;
using Xunit;

namespace Mavlink.UnitTests.Messages
{
    internal class MessageFactoryTests
    {
        protected IMessageFactory<ICommonMessage> MessageFactory;

        public MessageFactoryTests()
        {
            MessageFactory = new MessageFactory<ICommonMessage>();
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

        protected MessageId HeartbeatMessageId = MessageId.Heartbeat;
        protected MessageId ChangeOperatorControlMessageId = MessageId.ChangeOperatorControl;
        protected MessageId GpsStatusMessageId = MessageId.GpsStatus;

        public sealed class CreateMethodTests : MessageFactoryTests
        {
            [Fact]
            public void CreateThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => MessageFactory.CreateMessage(null, HeartbeatMessageId));
            }

            [Fact]
            public void CreateThrowInvalidOperationExceptionWhenEnumNotDefined()
            {
                Assert.Throws<InvalidOperationException>(() => MessageFactory.CreateMessage(new byte[] { }, (MessageId)254));
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

                HeartbeatMessage message = (HeartbeatMessage)MessageFactory.CreateMessage(HeartbeatMessagePayload, HeartbeatMessageId);

                Assert.NotNull(message);
                Assert.Equal(expectedAutopilot, message.Autopilot);
                Assert.Equal(expectedType, message.Type);
                Assert.Equal(expectedCustomMode, message.CustomMode);
                Assert.Equal(expectedBaseMode, message.BaseMode);
                Assert.Equal(expectedSystemStatus, message.SystemStatus);
                Assert.Equal(expectedMavlinkVersion, message.MavlinkVersion);
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

                ChangeOperatorControlMessage message = (ChangeOperatorControlMessage)MessageFactory.CreateMessage(ChangeOperatorControlMessagePayload, ChangeOperatorControlMessageId);

                Assert.NotNull(message);
                Assert.Equal(expectedTargetSystem, message.TargetSystem);
                Assert.Equal(expectedControlRequest, message.ControlRequest);
                Assert.Equal(expectedVersion, message.Version);
                Assert.Equal(expectedPasskey, message.Passkey);
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

                GpsStatusMessage message = (GpsStatusMessage)MessageFactory.CreateMessage(GpsStatusMessagePayload, GpsStatusMessageId);

                Assert.NotNull(message);
                Assert.Equal(satellitesVisible, message.SatellitesVisible);
                Assert.Equal(satellitePrn, message.SatellitePrn);
                Assert.Equal(satelliteUsed, message.SatelliteUsed);
                Assert.Equal(satelliteElevation, message.SatelliteElevation);
                Assert.Equal(satelliteAzimuth, message.SatelliteAzimuth);
                Assert.Equal(satelliteSnr, message.SatelliteSnr);
            }
        }
    }
}