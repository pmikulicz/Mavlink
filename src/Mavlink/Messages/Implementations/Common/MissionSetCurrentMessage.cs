// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionSetCurrentMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Set the mission item with sequence number seq as current item.
//   This means that the MAV will continue to this mission item on the shortest path (not following the mission items in-between)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Set the mission item with sequence number seq as current item.
    /// This means that the MAV will continue to this mission item on the shortest path (not following the mission items in-between)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionSetCurrentMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.MissionSetCurrent;

        /// <summary>
        /// Gets or sets sequence
        /// </summary>
        public ushort Sequence { get; set; }

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }
    }
}