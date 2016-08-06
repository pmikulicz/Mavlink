using Mavlink.Messages.Models;

namespace Mavlink.Messages.Types
{
    public enum MessageId : byte
    {
        [MessageStruct(typeof(HeartbeatMessage))]
        Heartbeat = 0
    }
}