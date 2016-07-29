// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavState.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines mavlink states
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Types
{
    /// <summary>
    /// Defines mavlink states
    /// </summary>
    public enum MavState : byte
    {
        /// <summary>
        /// Uninitialized system, state is unknown
        /// </summary>
        Uninit = 0,

        /// <summary>
        /// System is booting up
        /// </summary>
        Boot = 1,

        /// <summary>
        /// System is calibrating and not flight-ready
        /// </summary>
        Calibrating = 2,

        /// <summary>
        /// System is grounded and on standby.
        /// It can be launched any time
        /// </summary>
        Standby = 3,

        /// <summary>
        /// System is active and might be already airborne.
        /// Motors are engaged
        /// </summary>
        Active = 4,

        /// <summary>
        /// System is in a non-normal flight mode.
        /// It can however still navigate
        /// </summary>
        Critical = 5,

        /// <summary>
        /// System is in a non-normal flight mode.
        /// It lost control over parts or over the whole airframe.
        /// It is in mayday and going down
        /// </summary>
        Emergency = 6,

        /// <summary>
        /// System just initialized its power-down sequence, will shut down now
        /// </summary>
        Poweroff = 7
    }
}