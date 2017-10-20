// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents abstract model of mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Represents abstract model of mavlink message
    /// </summary>
    public abstract class MavlinkMessage
    {
        protected MavlinkMessage()
        {
        }

        /// <summary>
        /// Gest mavlink message id
        /// </summary>
        public abstract MessageId Id { get; }
    }
}