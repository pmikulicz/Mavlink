// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalPositionNedMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The filtered local position (e.g. fused computer vision and accelerometers). 
//   Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The filtered local position (e.g. fused computer vision and accelerometers). 
    /// Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LocalPositionNedMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.LocalPositionNed;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets x position
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets y position
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets z position
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Gets or sets x speed
        /// </summary>
        public float Vx { get; set; }

        /// <summary>
        /// Gets or sets y speed
        /// </summary>
        public float Vy { get; set; }

        /// <summary>
        /// Gets or sets z speed
        /// </summary>
        public float Vz { get; set; }
    }
}