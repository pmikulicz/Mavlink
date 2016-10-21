// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavSysStatusSensor.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines encode the sensors whose status is sent as part of the SYS_STATUS message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines encode the sensors whose status is sent as part of the SYS_STATUS message
    /// </summary>
    [Flags]
    public enum MavSysStatusSensor : uint
    {
        /// <summary>
        /// 3D gyro
        /// </summary>
        ThreeDGyro = 1,

        /// <summary>
        /// 3D accelerometer
        /// </summary>
        ThreeDAccel = 2,

        /// <summary>
        /// 3D magnetometer
        /// </summary>
        ThreeDMag = 4,

        /// <summary>
        /// Absolute pressure
        /// </summary>
        AbsolutePressure = 8,

        /// <summary>
        /// Differential pressure
        /// </summary>
        DifferentialPressure = 16,

        /// <summary>
        /// GPS
        /// </summary>
        Gps = 32,

        /// <summary>
        /// Optical flow
        /// </summary>
        OpticalFlow = 64,

        /// <summary>
        /// Computer vision position
        /// </summary>
        VisionPosition = 128,

        /// <summary>
        /// Laser based position
        /// </summary>
        LaserPosition = 256,

        /// <summary>
        /// External ground truth (Vicon or Leica)
        /// </summary>
        ExternalGroundTruth = 512,

        /// <summary>
        /// 3D angular rate control
        /// </summary>
        AngularRateControl = 1024,

        /// <summary>
        /// Attitude stabilization
        /// </summary>
        AttitudeStabilization = 2048,

        /// <summary>
        /// Yaw position
        /// </summary>
        YawPosition = 4096,

        /// <summary>
        /// Z/altitude control
        /// </summary>
        ZAltitudeControl = 8192,

        /// <summary>
        /// X/Y position control
        /// </summary>
        XyPositionControl = 16384,

        /// <summary>
        /// Motor outputs / control
        /// </summary>
        MotorOutputs = 32768,

        /// <summary>
        /// RC receiver
        /// </summary>
        RcReceiver = 65536
    }
}