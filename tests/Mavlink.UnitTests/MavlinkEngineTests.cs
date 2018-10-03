using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Mavlink.Packets;
using Moq;

namespace Mavlink.UnitTests
{
    public class MavlinkEngineTests
    {
        private readonly IMavlinkEngine<IArdupilotMessage> _mavlinkEngine;

        private static readonly Mock<IMessageProcessor<IArdupilotMessage>> MessageProcessorMock =
            new Mock<IMessageProcessor<IArdupilotMessage>>();

        private static readonly Mock<IPacketBuilderDirector> PacketBuilderDirectorMock =
            new Mock<IPacketBuilderDirector>();

        public MavlinkEngineTests()
        {
            _mavlinkEngine =
                new MavlinkEngine<IArdupilotMessage>(MessageProcessorMock.Object,
                    () => PacketBuilderDirectorMock.Object);
        }

        public sealed class CreatePacketTests : MavlinkEngineTests
        {
            public void CreatePacket_NullMessage_ThrowArgumentNullException()
            {
            }
        }
    }
}