// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavMissionType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines type of mission items being requested/sent in mission protocol.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines type of mission items being requested/sent in mission protocol
    /// </summary>
    public enum MavMissionType : byte
    {
        /// <summary>
        /// Items are mission commands for main mission
        /// </summary>
        Mission = 0,

        /// <summary>
        /// Specifies GeoFence area(s).
        /// Items are MAV_CMD_FENCE_ GeoFence items
        /// </summary>
        Fence = 1,

        /// <summary>
        /// Specifies the rally points for the vehicle.
        /// Rally points are alternative RTL points.
        /// Items are MAV_CMD_RALLY_POINT rally point items
        /// </summary>
        Rally = 2,

        /// <summary>
        /// Only used in MISSION_CLEAR_ALL to clear all mission types
        /// </summary>
        All = 255
    }
}