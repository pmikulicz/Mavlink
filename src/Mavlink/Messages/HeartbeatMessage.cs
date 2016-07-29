using Mavlink.Messages.Types;

namespace Mavlink.Messages
{
    public sealed class HeartbeatMessage : Message
    {
        public HeartbeatMessage(MavType type, MavAutopilot autopilot, MavModeFlag baseMode, uint customMode, byte mavlinkVersion)
        {
            Type = type;
            Autopilot = autopilot;
            BaseMode = baseMode;
            CustomMode = customMode;
            MavlinkVersion = mavlinkVersion;
        }

        /// <summary>
        /// Gets id of the message
        /// </summary>
        public override int Id => 0;

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
        /// A bitfield for use for autopilot-specific flags
        /// </summary>
        public uint CustomMode { get; }

        /// <summary>
        /// System status flag
        /// </summary>
        public MavState SystemStatus { get; set; }

        /// <summary>
        /// Mavlink version
        /// </summary>
        public byte MavlinkVersion { get; }
    }
}