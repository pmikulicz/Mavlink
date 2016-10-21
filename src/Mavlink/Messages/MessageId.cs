// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageId.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines all mavlink message ids
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Implementations.Common;

namespace Mavlink.Messages
{
    /// <summary>
    /// Defines all mavlink message ids
    /// </summary>
    public enum MessageId : byte
    {
        /// <summary>
        /// The heartbeat message shows that a system is present and responding
        /// </summary>
        [MessageStruct(typeof(HeartbeatMessage))]
        Heartbeat = 0,

        /// <summary>
        /// The general system state
        /// </summary>
        [MessageStruct(typeof(SysStatusMessage))]
        SysStatus = 1,

        /// <summary>
        /// The system time is the time of the master clock,
        /// typically the computer clock of the main onboard computer
        /// </summary>
        [MessageStruct(typeof(SystemTimeMessage))]
        SystemTime = 2,

        /// <summary>
        /// A ping message either requesting or responding to a ping.
        /// This allows to measure the system latencies, including serial port, radio modem and UDP connections
        /// </summary>
        [MessageStruct(typeof(PingMessage))]
        Ping = 4,

        /// <summary>
        /// Request to control this MAV
        /// </summary>
        [MessageStruct(typeof(ChangeOperatorControlMessage))]
        ChangeOperatorControl = 5,

        /// <summary>
        /// Accept or deny control of this MAV
        /// </summary>
        [MessageStruct(typeof(ChangeOperatorControlAckMessage))]
        ChangeOperatorControlAck = 6,

        /// <summary>
        /// Emit an encrypted signature/ key identifying this system.
        /// This protocol has been kept simple, so transmitting the key requires an encrypted channel for true safety
        /// </summary>
        [MessageStruct(typeof(AuthKeyMessage))]
        AuthKey = 7,

        /// <summary>
        /// Request to read the onboard parameter with the param_id string id.
        /// Onboard parameters are stored as key[const char*] -> value[float].
        /// This allows to send a parameter to any other component (such as the GCS)
        /// without the need of previous knowledge of possible parameter names.
        /// Thus the same GCS can store different parameters for different autopilots.
        /// See also http://qgroundcontrol.org/parameter_interface for a full documentation of QGroundControl and IMU code.
        /// </summary>
        [MessageStruct(typeof(ParamRequestReadMessage))]
        ParamRequestRead = 20,

        /// <summary>
        /// Request all parameters of this component. After this request, all parameters are emitted
        /// </summary>
        [MessageStruct(typeof(ParamRequestListMessage))]
        ParamRequestList = 21,

        /// <summary>
        /// Emit the value of a onboard parameter.
        /// The inclusion of param_count and param_index in the message allows the recipient to keep track of received parameters
        /// and allows him to re-request missing parameters after a loss or timeout
        /// </summary>
        [MessageStruct(typeof(ParamValueMessage))]
        ParamValue = 22,

        /// <summary>
        /// Set a parameter value TEMPORARILY to RAM. It will be reset to default on system reboot.
        /// Send the ACTION MAV_ACTION_STORAGE_WRITE to PERMANENTLY write the RAM contents to EEPROM.
        /// Iimportant is that receiving component should acknowledge the new parameter value by sending a param_value message to all communication partners.
        /// This will also ensure that multiple GCS all have an up-to-date list of all parameters.
        /// If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message
        /// </summary>
        [MessageStruct(typeof(ParamSetMessage))]
        ParamSet = 23
    }
}