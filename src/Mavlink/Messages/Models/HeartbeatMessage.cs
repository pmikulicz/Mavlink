using Mavlink.Messages.Types;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeartbeatMessage : IMessage
    {
        public HeartbeatMessage(MavType type, MavAutopilot autopilot, MavModeFlag baseMode, uint customMode, MavState systemStatus, byte mavlinkVersion)
        {
            Type = type;
            Autopilot = autopilot;
            BaseMode = baseMode;
            CustomMode = customMode;
            SystemStatus = systemStatus;
            MavlinkVersion = mavlinkVersion;
        }

        /// <summary>
        /// Gets type of the message
        /// </summary>
        public MessageId Id => MessageId.Heartbeat;

        /// <summary>
        /// A bitfield for use for autopilot-specific flags
        /// </summary>
        public uint CustomMode { get; }

        /// <summary>
        /// Type of the mavlink
        /// </summary>
        public MavType Type { get; }

        /// <summary>
        /// Autopilot type
        /// </summary>
        public MavAutopilot Autopilot { get; }

        /// <summary>
        /// System mode bitfield
        /// </summary>
        public MavModeFlag BaseMode { get; }

        /// <summary>
        /// System status flag
        /// </summary>
        public MavState SystemStatus { get; }

        /// <summary>
        /// Mavlink version
        /// </summary>
        public byte MavlinkVersion { get; }
    }
}