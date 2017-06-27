// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionItemMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Message encoding a mission item. This message is emitted to announce the presence of a mission item and to set a mission item on the system. 
//   The mission item can be either in x, y, z meters (type: LOCAL) or x: lat, y: lon, z: altitude. Local frame is Z-down, right handed (NED), global frame is Z-up, right handed (ENU).
//   See also http://qgroundcontrol.org/mavlink/waypoint_protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Message encoding a mission item. This message is emitted to announce the presence of a mission item and to set a mission item on the system.
    /// The mission item can be either in x, y, z meters (type: LOCAL) or x: lat, y: lon, z: altitude. Local frame is Z-down, right handed (NED), global frame is Z-up, right handed (ENU).
    /// See also http://qgroundcontrol.org/mavlink/waypoint_protocol
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionItemMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionItem;

        /// <summary>
        /// Gets or sets first parameter. See also <seealso cref="MavCmd"/>
        /// </summary>
        public float FirstParameter { get; set; }

        /// <summary>
        /// Gets or sets second parameter. See also <seealso cref="MavCmd"/>
        /// </summary>
        public float SecondParameter { get; set; }

        /// <summary>
        /// Gets or sets third parameter. See also <seealso cref="MavCmd"/>
        /// </summary>
        public float ThirdParameter { get; set; }

        /// <summary>
        /// Gets or sets fourth parameter. See also <seealso cref="MavCmd"/>
        /// </summary>

        public float FourthParameter { get; set; }

        /// <summary>
        /// Gets or sets fifth parameter/ local: x position, global: latitude
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets sixth parameter/ local: y position: global: longitude
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets seventh parameter/ local: z position: global: altitude (relative or absolute, depending on frame
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Gets or sets sequence
        /// </summary>
        public ushort Sequence { get; set; }

        /// <summary>
        /// Gets or sets scheduled action for the MISSION. See also <seealso cref="MavCmd"/>
        /// </summary>
        public MavCmd Command { get; set; }

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }

        /// <summary>
        /// Gets or sets coordinate system of the MISSION. See also <seealso cref="MavFrame"/>
        /// </summary>
        public MavFrame Frame { get; set; }

        /// <summary>
        /// Gets or sets flag indicating current item: false: 0, true: 1
        /// </summary>
        public byte Current { get; set; }

        /// <summary>
        /// Gets or sets autocontinue to next wp
        /// </summary>
        public byte Autocontinue { get; set; }

        /// <summary>
        /// Gets or sets mission type. See also <seealso cref="MavMissionType"/>
        /// </summary>
        public MavMissionType MissionType { get; set; }


    }
}