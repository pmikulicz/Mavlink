// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemTimeMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The system time is the time of the master clock, typically the computer clock of the main onboard computer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The system time is the time of the master clock, typically the computer clock of the main onboard computer
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SystemTimeMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.SystemTime;

        /// <summary>
        /// Gets or sets timestamp of the master clock in microseconds since UNIX epoch
        /// </summary>
        public ulong TimeUnixUsec { get; set; }

        /// <summary>
        /// Gets or sets timestamp of the component clock since boot time in milliseconds
        /// </summary>
        public uint TimeBootMs { get; set; }
    }
}