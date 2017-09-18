// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionRequestMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request the information of the mission item with the sequence number seq.
//   The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request the information of the mission item with the sequence number seq.
    /// The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionRequestMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.MissionRequest;

        /// <summary>
        /// Gets or sets sequence number
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

        /// <summary>
        /// Gets or sets mission type. See also <seealso cref="MavMissionType"/>
        /// </summary>
        public MavMissionType MissionType { get; set; }
    }
}