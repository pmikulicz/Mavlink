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
            0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03
        };

        protected MessageId MessageId = MessageId.Heartbeat;

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
                Assert.Throws<ArgumentNullException>(() => MessageFactory.CreateMessage(null, MessageId));
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

                HeartbeatMessage message = (HeartbeatMessage)MessageFactory.CreateMessage(HeartbeatMessagePayload, MessageId);

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