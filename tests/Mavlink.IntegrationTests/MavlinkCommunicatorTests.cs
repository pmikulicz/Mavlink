using Mavlink.Messages;
using Mavlink.Messages.Models;
using Mavlink.Messages.Types;
using NUnit.Framework;
using System.IO;
using System.Threading;

namespace Mavlink.IntegrationTests
{
    [TestFixture]
    public class MavlinkCommunicatorTests
    {
        protected IMavlinkCommunicatorFactory MavlinkCommunicatorFactory;
        protected Stream Stream;
        private const string StreamPath = @"E:\Desktop";

        protected readonly byte[] HeartbeatPacketPayload =
           {
                0xFE, 0x09, 0x4E, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x03,
                0x51, 0x04, 0x03, 0x1C, 0x7F
            };

        [SetUp]
        public void SetUp()
        {
            MavlinkCommunicatorFactory = new MavlinkCommunicatorFactory();
            Stream = File.Create($@"{StreamPath}\packets");
        }

        [TestFixture]
        public sealed class SubscribeForReceiveTests : MavlinkCommunicatorTests
        {
            [Test]
            public void SubscribeForReceiveGetTheSameMessageAsSend()
            {
                HeartbeatMessage receivedHeartbeat = default(HeartbeatMessage);
                IMavlinkCommunicator mavlinkCommunicator = MavlinkCommunicatorFactory.Create(Stream);
                IMessageNotifier messageNotifier = mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.Heartbeat);
                messageNotifier.MessageReceived += (s, e) =>
                {
                    receivedHeartbeat = (HeartbeatMessage)e.Message;
                };

                HeartbeatMessage sentHeartbetat = new HeartbeatMessage
                {
                    Autopilot = MavAutopilot.Ardupilotmega,
                    BaseMode =
                        MavModeFlag.CustomModeEnabled | MavModeFlag.StabilizeEnabled | MavModeFlag.ManualInputEnabled,
                    MavlinkVersion = 3,
                    Type = MavType.Quadrotor,
                    SystemStatus = MavState.Active,
                    CustomMode = 0
                };
                mavlinkCommunicator.SendMessage(sentHeartbetat, 1, 1);

                Stream.Seek(0, SeekOrigin.Begin);

                Thread.Sleep(3000);
                Assert.AreEqual(sentHeartbetat.Autopilot, receivedHeartbeat.Autopilot);
                Assert.AreEqual(sentHeartbetat.Type, receivedHeartbeat.Type);
                Assert.AreEqual(sentHeartbetat.CustomMode, receivedHeartbeat.CustomMode);
                Assert.AreEqual(sentHeartbetat.BaseMode, receivedHeartbeat.BaseMode);
                Assert.AreEqual(sentHeartbetat.SystemStatus, receivedHeartbeat.SystemStatus);
                Assert.AreEqual(sentHeartbetat.MavlinkVersion, receivedHeartbeat.MavlinkVersion);
                mavlinkCommunicator.Dispose();
                Thread.Sleep(1000);
            }
        }
    }
}