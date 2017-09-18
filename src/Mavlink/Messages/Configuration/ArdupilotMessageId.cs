using Mavlink.Messages.Dialects.Ardupilot;

namespace Mavlink.Messages.Configuration
{
    public class ArdupilotMessageId : MessageId
    {
        public ArdupilotMessageId(ArdupilotId ardupilotId)
        {
            ArdupilotId = ardupilotId;
        }

        public ArdupilotId ArdupilotId { get; }

        public override int Value => (int) ArdupilotId;
    }
}