// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionItemReachedMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   A certain mission item has been reached.
//   The system will either hold this position (or circle on the orbit) or (if the autocontinue on the WP was set) continue to the next mission
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// A certain mission item has been reached.
    /// The system will either hold this position (or circle on the orbit) or (if the autocontinue on the WP was set) continue to the next mission
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionItemReachedMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionItemReached;

        /// <summary>
        /// Gets or sets sequence
        /// </summary>
        public ushort Sequence { get; set; }
    }
}