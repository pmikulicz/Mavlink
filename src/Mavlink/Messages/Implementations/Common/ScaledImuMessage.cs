// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaledImuMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  The RAW IMU readings for the usual 9DOF sensor setup. This message should contain the scaled values to the described units
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The RAW IMU readings for the usual 9DOF sensor setup. This message should contain the scaled values to the described units
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ScaledImuMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ScaledImu;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets X acceleration (mg)
        /// </summary>
        public short Xacc { get; set; }

        /// <summary>
        /// Gets or sets Y acceleration (mg)
        /// </summary>
        public short Yacc { get; set; }

        /// <summary>
        /// Gets or sets Z acceleration (mg)
        /// </summary>
        public short Zacc { get; set; }

        /// <summary>
        /// Gets or sets angular speed around X axis (millirad /sec)
        /// </summary>
        public short Xgyro { get; set; }

        /// <summary>
        /// Gets or sets angular speed around Y axis (millirad /sec)
        /// </summary>
        public short Ygyro { get; set; }

        /// <summary>
        /// Gets or sets angular speed around Z axis (millirad /sec)
        /// </summary>
        public short Zgyro { get; set; }

        /// <summary>
        /// Gets or sets X Magnetic field (milli tesla)
        /// </summary>
        public short Xmag { get; set; }

        /// <summary>
        /// Gets or sets Y Magnetic field (milli tesla)
        /// </summary>
        public short Ymag { get; set; }

        /// <summary>
        /// Gets or sets Z Magnetic field (milli tesla)
        /// </summary>
        public short Zmag { get; set; }
    }
}