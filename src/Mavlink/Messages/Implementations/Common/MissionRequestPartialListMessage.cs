// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionRequestPartialListMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request a partial list of mission items from the system/component. http://qgroundcontrol.org/mavlink/waypoint_protocol. 
//   If start and end index are the same, just send one waypoint
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request a partial list of mission items from the system/component. http://qgroundcontrol.org/mavlink/waypoint_protocol. 
    /// If start and end index are the same, just send one waypoint
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionRequestPartialListMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionRequestPartialList;

        /// <summary>
        /// Gets or sets start index, 0 by default and smaller / equal to the largest index of the current onboard list
        /// </summary>
        public short StartIndex { get; set; }

        /// <summary>
        /// Gets or sets end index, equal or greater than start index
        /// </summary>
        public short EndIndex { get; set; }

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }

        /// <summary>
        /// Gets or sets sission type. See also <seealso cref="MavMissionType"/>
        /// </summary>
        public MavMissionType MissionType { get; set; }

    }
}