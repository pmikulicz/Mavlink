// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavFrame.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines frame types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines frame types
    /// </summary>
    public enum MavFrame
    {
        /// <summary>
        /// Global coordinate frame, WGS84 coordinate system. First value / x: latitude, second value / y: longitude, third value / z: positive altitude over mean sea level (MSL)
        /// </summary>
        FrameGlobal = 0,

        /// <summary>
        /// Local coordinate frame, Z-up (x: north, y: east, z: down) 
        /// </summary>
        FrameLocalNed = 1,

        /// <summary>
        /// NOT a coordinate frame, indicates a mission command
        /// </summary>
        FrameMission = 2,

        /// <summary>
        /// Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position.
        /// First value / x: latitude, second value / y: longitude, third value / z: positive altitude with 0 being at the altitude of the home location
        /// </summary>
        FrameGlobalRelativeAlt = 3,

        /// <summary>
        /// Local coordinate frame, Z-down (x: east, y: north, z: up)
        /// </summary>
        FrameLocalEnu = 4,

        /// <summary>
        /// Global coordinate frame, WGS84 coordinate system. 
        /// First value / x: latitude in degrees*1.0e-7, second value / y: longitude in degrees*1.0e-7, third value / z: positive altitude over mean sea level (MSL)
        /// </summary>
        FrameGlobalInt = 5, 

        /// <summary>
        /// Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. 
        /// First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude with 0 being at the altitude of the home location
        /// </summary>
        FrameGlobalRelativeAltInt = 6,

        /// <summary>
        /// Offset to the current local frame. Anything expressed in this frame should be added to the current local frame position
        /// </summary>
        FrameLocalOffsetNed = 7,

        /// <summary>
        /// Setpoint in body NED frame. This makes sense if all position control is externalized - e.g. useful to command 2 m/s^2 acceleration to the right
        /// </summary>
        FrameBodyNed = 8,

        /// <summary>
        /// Offset in body NED frame. This makes sense if adding setpoints to the current flight path, to avoid an obstacle - e.g. useful to command 2 m/s^2 acceleration to the east
        /// </summary>
        FrameBodyOffsetNed = 9, 

        /// <summary>
        /// Global coordinate frame with above terrain level altitude. WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. 
        /// First value / x: latitude in degrees, second value / y: longitude in degrees, third value / z: positive altitude in meters with 0 being at ground level in terrain model
        /// </summary>
        FrameGlobalTerrainAlt = 10,

        /// <summary>
        /// Global coordinate frame with above terrain level altitude. 
        /// WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. 
        /// First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, 
        /// third value / z: positive altitude in meters with 0 being at ground level in terrain model
        /// </summary>
        FrameGlobalTerrainAltInt = 11
    }
}