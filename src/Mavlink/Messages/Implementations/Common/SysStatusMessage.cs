// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysStatusMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  The general system state. If the system is following the MAVLink standard, the system state is mainly defined by three orthogonal states/modes:
//  The system mode, which is either LOCKED (motors shut down and locked), MANUAL (system under RC control),
//  GUIDED (system with autonomous position control, position setpoint controlled manually) or AUTO (system guided by path/waypoint planner).
//  The NAV_MODE defined the current flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR.
//  This represents the internal navigation state machine. The system status shows wether the system is currently active or not and if an emergency occured.
//  During the CRITICAL and EMERGENCY states the MAV is still considered to be active, but should start emergency procedures autonomously.
//  After a failure occured it should first move from active to critical to allow manual intervention and then move to emergency after a certain timeout
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The general system state. If the system is following the MAVLink standard, the system state is mainly defined by three orthogonal states/modes:
    /// The system mode, which is either LOCKED (motors shut down and locked), MANUAL (system under RC control),
    /// GUIDED (system with autonomous position control, position setpoint controlled manually) or AUTO (system guided by path/waypoint planner).
    /// The NAV_MODE defined the current flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR.
    /// This represents the internal navigation state machine. The system status shows wether the system is currently active or not and if an emergency occured.
    /// During the CRITICAL and EMERGENCY states the MAV is still considered to be active, but should start emergency procedures autonomously.
    /// After a failure occured it should first move from active to critical to allow manual intervention and then move to emergency after a certain timeout
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SysStatusMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.SysStatus;

        /// <summary>
        /// Gets or sets onboard controllers and sensors which are present.
        /// Value of 0: not present. Value of 1: present.
        /// Indices defined by ENUM MAV_SYS_STATUS_SENSOR onboard controllers and sensors are present.
        /// See also <seealso cref="MavSysStatusSensor"/>
        /// </summary>
        public MavSysStatusSensor SensorsPresent { get; set; }

        /// <summary>
        /// Gets or sets onboard controllers and sensors which are enabled.
        /// Value of 0: not present. Value of 1: present.
        /// Indices defined by ENUM MAV_SYS_STATUS_SENSOR onboard controllers and sensors are present.
        /// See also <seealso cref="MavSysStatusSensor"/>
        /// </summary>
        public MavSysStatusSensor SensorsEnabled { get; set; }

        /// <summary>
        /// Gets or sets onboard controllers and sensors which are operational or have an error.
        /// Value of 0: not present. Value of 1: present.
        /// Indices defined by ENUM MAV_SYS_STATUS_SENSOR onboard controllers and sensors are present.
        /// See also <seealso cref="MavSysStatusSensor"/>
        /// </summary>
        public MavSysStatusSensor SensorsHealth { get; set; }

        /// <summary>
        /// Gets or sets maximum usage in percent of the mainloop time, (0%: 0, 100%: 1000).
        /// Should be always below 1000
        /// </summary>
        public ushort Load { get; set; }

        /// <summary>
        /// Gets or sets battery voltage, in millivolts (1 = 1 millivolt)
        /// </summary>
        public ushort VoltageBattery { get; set; }

        /// <summary>
        /// Gets or sets battery current, in 10*milliamperes (1 = 10 milliampere).
        /// -1: autopilot does not measure the curren
        /// </summary>
        public short CurrentBattery { get; set; }

        /// <summary>
        /// Gets or sets remaining battery energy: (0%: 0, 100%: 100).
        /// -1: autopilot estimate the remaining battery
        /// </summary>
        public sbyte BatteryRemaining { get; set; }

        /// <summary>
        /// Gets or sets communication drops in percent, (0%: 0, 100%: 10'000), (UART, I2C, SPI, CAN),
        /// dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        public ushort DropRateComm { get; set; }

        /// <summary>
        /// Gets or sets communication errors (UART, I2C, SPI, CAN),
        /// dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        public ushort ErrorsComm { get; set; }

        /// <summary>
        /// Gets or sets autopilot-specific errors
        /// </summary>
        public ushort ErrorsFirstCount { get; set; }

        /// <summary>
        /// Gets or sets autopilot-specific errors
        /// </summary>
        public ushort ErrorsSecondCount { get; set; }

        /// <summary>
        /// Gets or sets autopilot-specific errors
        /// </summary>
        public ushort ErrorsThirdCount { get; set; }

        /// <summary>
        /// Gets or sets autopilot-specific errors
        /// </summary>
        public ushort ErrorsFourthCount { get; set; }
    }
}