// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttitudeMessage .cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AttitudeMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.Attitude;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets roll angle (rad, -pi..+pi)
        /// </summary>
        public float Roll { get; set; }

        /// <summary>
        /// Gets or sets pitch angle (rad, -pi..+pi)
        /// </summary>
        public float Pitch { get; set; }

        /// <summary>
        /// Gets or sets yaw angle (rad, -pi..+pi)
        /// </summary>
        public float Yaw { get; set; }

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