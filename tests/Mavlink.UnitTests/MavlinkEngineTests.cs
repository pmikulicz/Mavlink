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

        private static readonly Mock<IPacketHandler> PacketHandlerMock = new Mock<IPacketHandler>();

        private static readonly Mock<IMessageFactory<IArdupilotMessage>> MessageFactoryMock =
            new Mock<IMessageFactory<IArdupilotMessage>>();

        private static readonly Mock<IMessageMetadataContainer> MessageMetadataContainerMock =
            new Mock<IMessageMetadataContainer>();

        public MavlinkEngineTests()
        {
            _mavlinkEngine = new MavlinkEngine<IArdupilotMessage>(PacketHandlerMock.Object, MessageFactoryMock.Object);
        }

        public sealed class CreatePacketTests : MavlinkEngineTests
        {
            public void CreatePacket_NullMessage_ThrowArgumentNullException()
            {
            }
        }
    }
}