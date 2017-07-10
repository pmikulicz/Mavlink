// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionCurrentMessage .cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Message that announces the sequence number of the current active mission item. The MAV will fly towards this mission item
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Message that announces the sequence number of the current active mission item. The MAV will fly towards this mission item
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionCurrentMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionCurrent;

        /// <summary>
        /// Gets or sets sequence
        /// </summary>
        public ushort Sequence { get; set; }
    }
}