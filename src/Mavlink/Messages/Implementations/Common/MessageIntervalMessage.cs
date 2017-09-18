// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageIntervalMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   This interface replaces DATA_STREAM
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// This interface replaces DATA_STREAM
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MessageIntervalMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => Messages.MessageIdOld.MessageInterval;

        /// <summary>
        /// Gets or sets interval between two messages, in microseconds.
        /// A value of -1 indicates this stream is disabled, 0 indicates it is not available,
        /// > 0 indicates the interval at which it is sent
        /// </summary>
        public int IntervalUs { get; set; }

        /// <summary>
        /// Gets or sets id of the requested MAVLink message.
        /// V1.0 is limited to 254 messages
        /// </summary>
        public ushort MessageId { get; set; }
    }
}