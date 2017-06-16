// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GpsRawIntMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The global position, as returned by the Global Positioning System (GPS). This is NOT the global position estimate of the system, but rather a RAW sensor value.
//   See message GLOBAL_POSITION for the global position estimate. Coordinate frame is right-handed, Z-axis up (GPS frame)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The global position, as returned by the Global Positioning System (GPS). This is NOT the global position estimate of the system, but rather a RAW sensor value.
    /// See message GLOBAL_POSITION for the global position estimate. Coordinate frame is right-handed, Z-axis up (GPS frame)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GpsRawIntMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.GpsRawInt;

        /// <summary>
        /// Gets or sets timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        public ulong TimeUsec { get; set; }

        /// <summary>
        /// Gets or sets latitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Longitude { get; set; }

        /// <summary>
        /// Gets or sets altitude (AMSL, NOT WGS84), in meters * 1000 (positive for up).
        /// Note that virtually all GPS modules provide the AMSL altitude in addition to the WGS84 altitude
        /// </summary>
        public int Altitude { get; set; }

        /// <summary>
        /// Gets or sets GPS HDOP horizontal dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Eph { get; set; }

        /// <summary>
        /// Gets or sets GPS VDOP vertical dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Epv { get; set; }

        /// <summary>
        /// Gets or sets GPS ground speed (m/s * 100). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Vel { get; set; }

        /// <summary>
        /// Gets or sets course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees.
        /// If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Cog { get; set; }

        /// <summary>
        /// Gets or sets GPS fix type. See also <seealso cref="GpsFixType"/>
        /// </summary>
        public GpsFixType FixType { get; set; }

        /// <summary>
        /// Gets or sets number of satellites visible. If unknown, set to 255
        /// </summary>
        public byte SatellitesVisible { get; set; }
    }
}