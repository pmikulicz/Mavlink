using Mavlink.Messages;
using Mavlink.Messages.Models;
using Mavlink.Messages.Types;
using NUnit.Framework;
using System;

namespace Mavlink.UnitTests.Messages
{
    [TestFixture]
    internal class MessageFactoryTests
    {
        protected IMessageFactory MessageFactory;

        protected readonly byte[] HeartbeatMessagePayload =
        {
            0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03
            };

        protected MessageId MessageId = MessageId.Heartbeat;

        [SetUp]
        public void SetUp()
        {
            MessageFactory = new MessageFactory();
        }

        [TestFixture]
        public sealed class CreateTests : MessageFactoryTests
        {
            [Test]
            public void CreateThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => MessageFactory.Create(null, MessageId));
            }

            [Test]
            public void CreateThrowArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => MessageFactory.Create(new byte[] { }, (MessageId)254));
            }

            [Test]
            public void CreateReturnMessage()
            {
                var expectedType = MavType.Quadrotor;
                var expectedAutopilot = MavAutopilot.Ardupilotmega;
                var expectedBaseMode = MavModeFlag.CustomModeEnabled | MavModeFlag.StabilizeEnabled | MavModeFlag.ManualInputEnabled;
                int expectedCustomMode = 0;
                var expectedSystemStatus = MavState.Active;
                byte expectedMavlinkVersion = 3;

                HeartbeatMessage message = (HeartbeatMessage)MessageFactory.Create(HeartbeatMessagePayload, MessageId);

                Assert.AreNotEqual(null, message);
                Assert.AreEqual(expectedAutopilot, message.Autopilot);
                Assert.AreEqual(expectedType, message.Type);
                Assert.AreEqual(expectedCustomMode, message.CustomMode);
                Assert.AreEqual(expectedBaseMode, message.BaseMode);
                Assert.AreEqual(expectedSystemStatus, message.SystemStatus);
                Assert.AreEqual(expectedMavlinkVersion, message.MavlinkVersion);
            }
        }
    }
}