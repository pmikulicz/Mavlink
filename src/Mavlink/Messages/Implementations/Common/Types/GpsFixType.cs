// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GpsFixType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines types of GPS fix
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines types of GPS fix
    /// </summary>
    public enum GpsFixType : byte
    {
        /// <summary>
        /// No GPS connected
        /// </summary>
        GpsFixTypeNoGps = 0,

        /// <summary>
        /// No position information, GPS is connected
        /// </summary>
        GpsFixTypeNoFix = 1,

        /// <summary>
        /// 2D position
        /// </summary>
        GpsFixType_2DFix = 2,

        /// <summary>
        /// 3D position
        /// </summary>
        GpsFixType_3DFix = 3,

        /// <summary>
        /// DGPS/SBAS aided 3D position
        /// </summary>
        GpsFixTypeDgps = 4,

        /// <summary>
        /// RTK float, 3D position
        /// </summary>
        GpsFixTypeRtkFloat = 5,

        /// <summary>
        /// RTK Fixed, 3D position
        /// </summary>
        GpsFixTypeRtkFixed = 6,

        /// <summary>
        /// Static fixed, typically used for base stations
        /// </summary>
        GpsFixTypeStatic = 7
    }
}