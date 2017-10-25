namespace Mavlink.Messages.Dialects.Ardupilot
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