// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageId.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines all mavlink message ids
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Models;

namespace Mavlink.Messages
{
    /// <summary>
    /// Defines all mavlink message ids
    /// </summary>
    public enum MessageId : byte
    {
        /// <summary>
        /// The heartbeat message shows that a system is present and responding
        /// </summary>
        [MessageStruct(typeof(HeartbeatMessage))]
        Heartbeat = 0,

        /// <summary>
        /// The general system state
        /// </summary>
        [MessageStruct(typeof(SysStatusMessage))]
        SysStatus = 1,

        /// <summary>
        /// The system time is the time of the master clock,
        /// typically the computer clock of the main onboard computer
        /// </summary>
        [MessageStruct(typeof(SystemTimeMessage))]
        SystemTime = 2,
    }
}