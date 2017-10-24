using Mavlink.Messages.Dialects.Ardupilot;

namespace Mavlink.Messages.Configuration
{
    public sealed class ArdupilotMessageId : MessageId
    {
        public ArdupilotMessageId(ArdupilotId ardupilotId)
            : base((int)ardupilotId)
        {
            ArdupilotId = ardupilotId;
        }

        public ArdupilotId ArdupilotId { get; }
    }
}