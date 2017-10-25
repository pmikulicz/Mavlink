// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents interface for a model of mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Represents interface for a model of mavlink message
    /// </summary>
    public interface IMavlinkMessage
    {
        /// <summary>
        /// Gest mavlink message id
        /// </summary>
        MessageId Id { get; }
    }
}