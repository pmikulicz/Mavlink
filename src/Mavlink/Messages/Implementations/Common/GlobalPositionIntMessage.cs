// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalPositionIntMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The filtered global position (e.g. fused GPS and accelerometers). 
//   The position is in GPS-frame (right-handed, Z-up). It is designed as scaled integer message since the resolution of float is not sufficient
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The filtered global position (e.g. fused GPS and accelerometers). 
    /// The position is in GPS-frame (right-handed, Z-up). It is designed as scaled integer message since the resolution of float is not sufficient.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct GlobalPositionIntMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.GlobalPositionInt;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets latitude, expressed as degrees * 1E7
        /// </summary>
        public int Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude, expressed as degrees * 1E7
        /// </summary>
        public int Longitude { get; set; }

        /// <summary>
        /// Gets or sets altitude in meters, expressed as * 1000 (millimeters), AMSL (not WGS84 - note that virtually all GPS modules provide the AMSL as well)
        /// </summary>
        public int Altitude { get; set; }

        /// <summary>
        /// Gets or sets altitude above ground in meters, expressed as * 1000 (millimeters)
        /// </summary>
        public int RelativeAltitude { get; set; }

        /// <summary>
        /// Gets or sets ground x speed (latitude, positive north), expressed as m/s * 100
        /// </summary>
        public short Vx { get; set; }

        /// <summary>
        /// Gets or sets ground y speed (Longitude, positive east), expressed as m/s * 100
        /// </summary>
        public short Vy { get; set; }

        /// <summary>
        /// Gets or sets ground z speed (altitude, positive down), expressed as m/s * 100
        /// </summary>
        public short Vz { get; set; }

        /// <summary>
        /// Gets or sets vehicle heading (yaw angle) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Hdg { get; set; }


    }
}