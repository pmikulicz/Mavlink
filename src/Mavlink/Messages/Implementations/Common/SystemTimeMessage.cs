// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemTimeMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The system time is the time of the master clock, typically the computer clock of the main onboard computer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The system time is the time of the master clock, typically the computer clock of the main onboard computer
    /// </summary>
    public struct SystemTimeMessage : ICommonMessage
    {
        /// <summary>
        /// Gets or sets autopilot-specific errors id of the message
        /// </summary>
        public MessageId Id => MessageId.SystemTime;

        /// <summary>
        /// Gets or sets timestamp of the master clock in microseconds since UNIX epoch
        /// </summary>
        public ulong TimeUnixUSec { get; internal set; }

        /// <summary>
        /// Gets or sets timestamp of the component clock since boot time in milliseconds
        /// </summary>
        public uint TimeBootMs { get; internal set; }
    }
}