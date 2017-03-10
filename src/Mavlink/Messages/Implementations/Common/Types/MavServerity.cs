// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavServerity.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines the severity level, generally used for status messages to indicate their relative urgency.
//   Based on RFC-5424 using expanded definitions at: http://www.kiwisyslog.com/kb/info:-syslog-message-levels/
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines the severity level, generally used for status messages to indicate their relative urgency.
    /// Based on RFC-5424 using expanded definitions at: http://www.kiwisyslog.com/kb/info:-syslog-message-levels/
    /// </summary>
    public enum MavServerity : byte
    {
        /// <summary>
        /// System is unusable. This is a "panic" condition
        /// </summary>
        Emergency = 0,

        /// <summary>
        /// Action should be taken immediately. Indicates error in non-critical systems
        /// </summary>
        Alert = 1,

        /// <summary>
        /// Action must be taken immediately. Indicates failure in a primary system
        /// </summary>
        Critical = 2,

        /// <summary>
        /// Indicates an error in secondary/redundant systems
        /// </summary>
        Error = 3,

        /// <summary>
        /// Indicates about a possible future error if this is not resolved within a given timeframe.
        /// Example would be a low battery warning
        /// </summary>
        Warning = 4,

        /// <summary>
        /// An unusual event has occured, though not an error condition. This should be investigated for the root cause
        /// </summary>
        Notice = 5,

        /// <summary>
        /// Normal operational messages. Useful for logging. No action is required for these messages
        /// </summary>
        Info = 6,

        /// <summary>
        /// Useful non-operational messages that can assist in debugging. These should not occur during normal operation
        /// </summary>
        Debug = 7,
    }
}