using Mavlink.Messages.Dialects.Ardupilot;

namespace Mavlink.Messages.Configuration
{
    public sealed class HeartbeatMessageConfiguration : MessageConfiguration<HeartbeatMessage>
    {
        public override void Configure()
        {
            Message().SetName("").SetId(1);

            Property(hm => hm.Autopilot).SetName("").SetOrder(1);
            Property(hm => hm.BaseMode).SetName("").SetOrder(2);
            Property(hb => hb.CustomMode).SetOrder(3).SetName("gfdsfds");
        }
    }

    public sealed class ParamRequestReadMessageConfiguration : MessageConfiguration<ParamRequestReadMessage>
    {
        public override void Configure()
        {
            Message().SetId(12).SetName("");

            Property(p => p.ParamId).SetOrder(1).SetSize(14).SetName("fds");
        }
    }
}