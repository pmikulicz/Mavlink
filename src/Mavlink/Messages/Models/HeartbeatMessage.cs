// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeartbeatMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The heartbeat message shows that a system is present and responding.
//   The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Types;
using System.Runtime.InteropServices;

// ReSharper disable UnassignedGetOnlyAutoProperty

namespace Mavlink.Messages.Models
{
    /// <summary>
    /// The heartbeat message shows that a system is present and responding.
    /// The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HeartbeatMessage : IMessage
    {
        /// <summary>
        /// Gets id of the message
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