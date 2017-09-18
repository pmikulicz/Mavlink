// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeartbeatMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The heartbeat message shows that a system is present and responding.
//   The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Configuration;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Dialects.Ardupilot
{
    /// <summary>
    /// The heartbeat message shows that a system is present and responding.
    /// The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate
    /// </summary>
    public class HeartbeatMessage : ArdupilotMessage
    {
        /// <inheritdoc />
        public override MessageId Id => new ArdupilotMessageId(ArdupilotId.Heartbeat);

        /// <summary>
        /// Gets or sets a bitfield for use for autopilot-specific flags
        /// </summary>
        public uint CustomMode { get; set; }

        /// <summary>
        /// Gets or sets type of the mavlink. See also <seealso cref="MavType"/>
        /// </summary>
        public MavType Type { get; set; }

        /// <summary>
        /// Gets or sets autopilot type. See also <seealso cref="MavAutopilot"/>
        /// </summary>
        public MavAutopilot Autopilot { get; set; }

        /// <summary>
        /// Gets or sets system mode bitfield. See also <seealso cref="MavModeFlag"/>
        /// </summary>
        public MavModeFlag BaseMode { get; set; }

        /// <summary>
        /// Gets or sets system status flag. See also <seealso cref="MavState"/>
        /// </summary>
        public MavState SystemStatus { get; set; }

        /// <summary>
        /// Gets or sets mavlink version
        /// </summary>
        public byte MavlinkVersion { get; set; }
    }
}