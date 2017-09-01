using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common;
using Mavlink.Messages.Implementations.Common.Types;
using NUnit.Framework;
using System;

namespace Mavlink.UnitTests.Messages
{
    [TestFixture]
    internal class MessageFactoryTests
    {
        protected IMessageFactory<ICommonMessage> MessageFactory;

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

        [SetUp]
        public void SetUp()
        {
            MessageFactory = new MessageFactory<ICommonMessage>();
        }

        [TestFixture]
        public sealed class CreateMethodTests : MessageFactoryTests
        {
            [Test]
            public void CreateThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => MessageFactory.CreateMessage(null, HeartbeatMessageId));
            }

            [Test]
            public void CreateThrowInvalidOperationExceptionWhenEnumNotDefined()
            {
                Assert.Throws<InvalidOperationException>(() => MessageFactory.CreateMessage(new byte[] { }, (MessageId)254));
            }

            [Test]
            public void CreateReturnsMessage()
            {
                var expectedType = MavType.Quadrotor;
                var expectedAutopilot = MavAutopilot.Ardupilotmega;
                var expectedBaseMode = MavModeFlag.CustomModeEnabled | MavModeFlag.StabilizeEnabled | MavModeFlag.ManualInputEnabled;
                int expectedCustomMode = 0;
                var expectedSystemStatus = MavState.Active;
                byte expectedMavlinkVersion = 3;

                HeartbeatMessage message = (HeartbeatMessage)MessageFactory.CreateMessage(HeartbeatMessagePayload, HeartbeatMessageId);

                Assert.AreNotEqual(null, message);
                Assert.AreEqual(expectedAutopilot, message.Autopilot);
                Assert.AreEqual(expectedType, message.Type);
                Assert.AreEqual(expectedCustomMode, message.CustomMode);
                Assert.AreEqual(expectedBaseMode, message.BaseMode);
                Assert.AreEqual(expectedSystemStatus, message.SystemStatus);
                Assert.AreEqual(expectedMavlinkVersion, message.MavlinkVersion);
            }

            [Test]
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

                Assert.AreNotEqual(null, message);
                Assert.AreEqual(expectedTargetSystem, message.TargetSystem);
                Assert.AreEqual(expectedControlRequest, message.ControlRequest);
                Assert.AreEqual(expectedVersion, message.Version);
                Assert.AreEqual(expectedPasskey, message.Passkey);
            }

            [Test]
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

                Assert.AreNotEqual(null, message);
                Assert.AreEqual(satellitesVisible, message.SatellitesVisible);
                Assert.AreEqual(satellitePrn, message.SatellitePrn);
                Assert.AreEqual(satelliteUsed, message.SatelliteUsed);
                Assert.AreEqual(satelliteElevation, message.SatelliteElevation);
                Assert.AreEqual(satelliteAzimuth, message.SatelliteAzimuth);
                Assert.AreEqual(satelliteSnr, message.SatelliteSnr);
            }
        }
    }
}