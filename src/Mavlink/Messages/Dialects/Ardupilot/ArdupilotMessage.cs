namespace Mavlink.Messages.Dialects.Ardupilot
{
    public abstract class ArdupilotMessage : MavlinkMessage
    {
        public abstract ArdupilotId Id { get; }
    }
}