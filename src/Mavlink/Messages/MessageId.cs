// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageId.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines all mavlink message ids
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Implementations;
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
        [MessageDefinition(typeof(HeartbeatMessage))]
        Heartbeat = 0,

        /// <summary>
        /// The general system state
        /// </summary>
        [MessageDefinition(typeof(SysStatusMessage))]
        SysStatus = 1,

        /// <summary>
        /// The system time is the time of the master clock,
        /// typically the computer clock of the main onboard computer
        /// </summary>
        [MessageDefinition(typeof(SystemTimeMessage))]
        SystemTime = 2,

        /// <summary>
        /// A ping message either requesting or responding to a ping.
        /// This allows to measure the system latencies, including serial port, radio modem and UDP connections
        /// </summary>
        [MessageDefinition(typeof(PingMessage))]
        Ping = 4,

        /// <summary>
        /// Request to control this MAV
        /// </summary>
        [MessageDefinition(typeof(ChangeOperatorControlMessage))]
        ChangeOperatorControl = 5,

        /// <summary>
        /// Accept or deny control of this MAV
        /// </summary>
        [MessageDefinition(typeof(ChangeOperatorControlAckMessage))]
        ChangeOperatorControlAck = 6,

        /// <summary>
        /// Emit an encrypted signature/ key identifying this system.
        /// This protocol has been kept simple, so transmitting the key requires an encrypted channel for true safety
        /// </summary>
        [MessageDefinition(typeof(AuthKeyMessage))]
        AuthKey = 7,

        /// <summary>
        /// Request to read the onboard parameter with the param_id string id.
        /// Onboard parameters are stored as key[const char*] -> value[float].
        /// This allows to send a parameter to any other component (such as the GCS)
        /// without the need of previous knowledge of possible parameter names.
        /// Thus the same GCS can store different parameters for different autopilots.
        /// See also http://qgroundcontrol.org/parameter_interface for a full documentation of QGroundControl and IMU code.
        /// </summary>
        [MessageDefinition(typeof(ParamRequestReadMessage))]
        ParamRequestRead = 20,

        /// <summary>
        /// Request all parameters of this component. After this request, all parameters are emitted
        /// </summary>
        [MessageDefinition(typeof(ParamRequestListMessage))]
        ParamRequestList = 21,

        /// <summary>
        /// Emit the value of a onboard parameter.
        /// The inclusion of param_count and param_index in the message allows the recipient to keep track of received parameters
        /// and allows him to re-request missing parameters after a loss or timeout
        /// </summary>
        [MessageDefinition(typeof(ParamValueMessage))]
        ParamValue = 22,

        /// <summary>
        /// Set a parameter value TEMPORARILY to RAM. It will be reset to default on system reboot.
        /// Send the ACTION MAV_ACTION_STORAGE_WRITE to PERMANENTLY write the RAM contents to EEPROM.
        /// Iimportant is that receiving component should acknowledge the new parameter value by sending a param_value message to all communication partners.
        /// This will also ensure that multiple GCS all have an up-to-date list of all parameters.
        /// If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message
        /// </summary>
        [MessageDefinition(typeof(ParamSetMessage))]
        ParamSet = 23,

        /// <summary>
        /// The global position, as returned by the Global Positioning System (GPS).
        /// This is NOT the global position estimate of the system, but rather a RAW sensor value.
        /// See message GLOBAL_POSITION for the global position estimate. Coordinate frame is right-handed, Z-axis up (GPS frame)
        /// </summary>
        [MessageDefinition(typeof(GpsRawIntMessage))]
        GpsRawInt = 24,

        /// <summary>
        /// The positioning status, as reported by GPS. This message is intended to display status information about each satellite visible to the receiver.
        /// See message GLOBAL_POSITION for the global position estimate. This message can contain information for up to 20 satellites
        /// </summary>
        [MessageDefinition(typeof(GpsStatusMessage))]
        GpsStatus = 25,

        /// <summary>
        /// The RAW IMU readings for the usual 9DOF sensor setup. This message should contain the scaled values to the described units
        /// </summary>
        [MessageDefinition(typeof(ScaledImuMessage))]
        ScaledImu = 26,

        /// <summary>
        /// The RAW pressure readings for the typical setup of one absolute pressure and one differential pressure sensor.
        /// The sensor values should be the raw, UNSCALED ADC values
        /// </summary>
        [MessageDefinition(typeof(RawPressureMessage))]
        RawPressure = 28,

        /// <summary>
        /// The pressure readings for the typical setup of one absolute and differential pressure sensor. 
        /// The units are as specified in each field.
        /// </summary>
        [MessageDefinition(typeof(ScaledPressureMessage))]
        ScaledPressure = 29,

        /// <summary>
        /// The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right)
        /// </summary>
        [MessageDefinition(typeof(AttitudeMessage))]
        Attitude = 30,

        /// <summary>
        /// The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right), expressed as quaternion. 
        /// Quaternion order is w, x, y, z and a zero rotation would be expressed as (1 0 0 0).
        /// </summary>
        [MessageDefinition(typeof(AttitudeQuaternionMessage))]
        AttitudeQuaternion = 31,

        /// <summary>
        /// The filtered local position (e.g. fused computer vision and accelerometers).
        /// Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)
        /// </summary>
        [MessageDefinition(typeof(LocalPositionNedMessage))]
        LocalPositionNed = 32,

        /// <summary>
        /// The filtered global position (e.g. fused GPS and accelerometers). 
        /// The position is in GPS-frame (right-handed, Z-up). It is designed as scaled integer message since the resolution of float is not sufficient
        /// </summary>
        [MessageDefinition(typeof(GlobalPositionIntMessage))]
        GlobalPositionInt = 33,

        /// <summary>
        /// The scaled values of the RC channels received. (-100%) -10000, (0%) 0, (100%) 10000. 
        /// Channels that are inactive should be set to UINT16_MAX
        /// </summary>
        [MessageDefinition(typeof(RcChannelsScaledMessage))]
        RcChannelsScaled = 34,

        /// <summary>
        /// The RAW values of the RC channels received. 
        /// The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification.
        /// </summary>
        [MessageDefinition(typeof(RcChannelsRawMessage))]
        RcChannelsRaw = 35,

        /// <summary>
        /// The RAW values of the servo outputs (for RC input from the remote, use the RC_CHANNELS messages). 
        /// The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%
        /// </summary>
        [MessageDefinition(typeof(ServoOutputRawMessage))]
        ServoOutputRaw = 36,

        /// <summary>
        /// Request a partial list of mission items from the system/component. http://qgroundcontrol.org/mavlink/waypoint_protocol. 
        /// If start and end index are the same, just send one waypoint
        /// </summary>
        [MessageDefinition(typeof(MissionRequestPartialListMessage))]
        MissionRequestPartialList = 37,

        /// <summary>
        /// Message encoding a mission item. This message is emitted to announce the presence of a mission item and to set a mission item on the system. 
        /// The mission item can be either in x, y, z meters (type: LOCAL) or x: lat, y: lon, z: altitude. Local frame is Z-down, right handed (NED), global frame is Z-up, right handed (ENU).
        /// See also http://qgroundcontrol.org/mavlink/waypoint_protocol
        /// </summary>
        [MessageDefinition(typeof(MissionItemMessage))]
        MissionItem = 39,

        /// <summary>
        /// Request the information of the mission item with the sequence number seq.
        /// The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol
        /// </summary>
        [MessageDefinition(typeof(MissionRequestMessage))]
        MissionRequest = 40,

        /// <summary>
        /// This interface replaces data DATA_STREAM
        /// </summary>
        [MessageDefinition(typeof(MessageIntervalMessage))]
        MessageInterval = 244,

        /// <summary>
        /// Status text message. WARNING: They consume quite some bandwidth,
        /// so use only for important status and error messages.
        /// If implemented wisely, these messages are buffered on the MCU and sent only at a limited rate (e.g. 10 Hz)
        /// </summary>
        [MessageDefinition(typeof(StatusTextMessage))]
        StatusText = 253,
    }
}