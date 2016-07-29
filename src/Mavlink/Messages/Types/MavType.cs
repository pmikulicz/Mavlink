// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines types of micro air vehicles
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Types
{
    /// <summary>
    /// Defines types of micro air vehicles
    /// </summary>
    public enum MavType : byte
    {
        /// <summary>
        /// Generic micro air vehicle
        /// </summary>
        Generic = 0,

        /// <summary>
        /// Fixed wing aircraft
        /// </summary>
        FixedWing = 1,

        /// <summary>
        /// Quadrotor
        /// </summary>
        Quadrotor = 2,

        /// <summary>
        /// Coaxial helicopter
        /// </summary>
        Coaxial = 3,

        /// <summary>
        /// Normal helicopter with tail rotor
        /// </summary>
        Helicopter = 4,

        /// <summary>
        /// Ground installation
        /// </summary>
        AntennaTracker = 5,

        /// <summary>
        /// Operator control unit / ground control station
        /// </summary>
        Gcs = 6,

        /// <summary>
        /// Airship, controlled
        /// </summary>
        Airship = 7,

        /// <summary>
        /// Free balloon, uncontrolled
        /// </summary>
        FreeBalloon = 8,

        /// <summary>
        /// Rocket
        /// </summary>
        Rocket = 9,

        /// <summary>
        /// Ground rover
        /// </summary>
        GroundRover = 10,

        /// <summary>
        /// Surface vessel, boat, ship
        /// </summary>
        SurfaceBoat = 11,

        /// <summary>
        /// Submarine
        /// </summary>
        Submarine = 12,

        /// <summary>
        /// Hexarotor
        /// </summary>
        Hexarotor = 13,

        /// <summary>
        /// Octorotor
        /// </summary>
        Octorotor = 14,

        /// <summary>
        /// Octorotor
        /// </summary>
        Tricopter = 15,

        /// <summary>
        /// Flapping wing
        /// </summary>
        FlappingWing = 16,

        /// <summary>
        /// Flapping wing
        /// </summary>
        Kite = 17
    };
}