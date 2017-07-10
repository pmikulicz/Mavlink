// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttitudeQuaternionMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right), expressed as quaternion.
    /// Quaternion order is w, x, y, z and a zero rotation would be expressed as (1 0 0 0).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AttitudeQuaternionMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.AttitudeQuaternion;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets quaternion component 1, w (1 in null-rotation)
        /// </summary>
        public float FirstQuaternionComponent { get; set; }

        /// <summary>
        /// Gets or sets quaternion component 2, x (0 in null-rotation)
        /// </summary>
        public float SecondQuaternionComponent { get; set; }

        /// <summary>
        /// Gets or sets quaternion component 3, y (0 in null-rotation)
        /// </summary>
        public float ThirdQuaternionComponent { get; set; }

        /// <summary>
        /// Gets or sets quaternion component 4, z (0 in null-rotation)
        /// </summary>
        public float FourthQuaternionComponent { get; set; }

        /// <summary>
        /// Gets or sets roll angular speed (rad/s)
        /// </summary>
        public float RollSpeed { get; set; }

        /// <summary>
        /// Gets or sets pitch angular speed (rad/s)
        /// </summary>
        public float PitchSpeed { get; set; }

        /// <summary>
        /// Gets or sets yaw angular speed (rad/s)
        /// </summary>
        public float YawSpeed { get; set; }
    }
}