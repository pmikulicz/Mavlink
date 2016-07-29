// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavModeFlag.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines flags which encodes the MAV mode
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Types
{
    /// <summary>
    /// Defines flags which encodes the mavlink mode
    /// </summary>
    public enum MavModeFlag : byte
    {
        /// <summary>
        /// 0b10000000 MAV safety set to armed.
        /// Motors are enabled / running / can start. Ready to fly
        /// </summary>
        SafetyArmed = 128,

        /// <summary>
        /// 0b01000000 remote control input is enabled
        /// </summary>
        ManualInputEnabled = 64,

        /// <summary>
        /// 0b00100000 hardware in the loop simulation.
        /// All motors / actuators are blocked, but internal software is full operational
        /// </summary>
        HilEnabled = 32,

        /// <summary>
        /// 0b00010000 system stabilizes electronically its attitude (and optionally position).
        /// It needs however further control inputs to move around
        /// </summary>
        StabilizeEnabled = 16,

        /// <summary>
        /// 0b00001000 guided mode enabled, system flies MISSIONs / mission items
        /// </summary>
        GuidedEnabled = 8,

        /// <summary>
        /// 0b00000100 autonomous mode enabled, system finds its own goal positions.
        /// Guided flag can be set or not, depends on the actual implementation
        /// </summary>
        AutoEnabled = 4,

        /// <summary>
        /// 0b00000010 system has a test mode enabled.
        /// This flag is intended for temporary system tests and should not be used for stable implementations
        /// </summary>
        TestEnabled = 2,

        /// <summary>
        /// 0b00000001 Reserved for future use
        /// </summary>
        CustomModeEnabled = 1
    }
}