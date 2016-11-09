// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GpsStatusMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   The positioning status, as reported by GPS. This message is intended to display status information about each satellite visible to the receiver.
//   See message GLOBAL_POSITION for the global position estimate. This message can contain information for up to 20 satellites
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The positioning status, as reported by GPS. This message is intended to display status information about each satellite visible to the receiver.
    /// See message GLOBAL_POSITION for the global position estimate. This message can contain information for up to 20 satellites
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GpsStatusMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.GpsStatus;

        /// <summary>
        /// Gets or sets number of satellites visible
        /// </summary>
        public byte SatellitesVisible { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] satellitePrn;

        /// <summary>
        /// Gets or sets global satellite ID
        /// </summary>
        public byte[] SatellitePrn
        {
            get { return satellitePrn; }

            set { satellitePrn = value; }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] satelliteUsed;

        /// <summary>
        /// Gets or sets satellite usage. 0 represents satellite not used and 1 represents sattelite used for localization
        /// </summary>
        public byte[] SatelliteUsed
        {
            get { return satelliteUsed; }

            set { satelliteUsed = value; }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] satelliteElevation;

        /// <summary>
        /// Gets or sets elevation (0 is right on top of receiver, 90 is on the horizon) of satellite
        /// </summary>
        public byte[] SatelliteElevation
        {
            get { return satelliteElevation; }
            set { satelliteElevation = value; }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] satelliteAzimuth;

        /// <summary>
        /// Gets or sets direction of satellite. 0 represents 0 deg, 255 represents 360 deg
        /// </summary>
        public byte[] SatelliteAzimuth
        {
            get { return satelliteAzimuth; }

            set { satelliteAzimuth = value; }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] satelliteSnr;

        /// <summary>
        /// Gets or sets signal to noise ratio of satellite
        /// </summary>
        public byte[] SatelliteSnr
        {
            get { return satelliteSnr; }

            set { satelliteSnr = value; }
        }
    }
}