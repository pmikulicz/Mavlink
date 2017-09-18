// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaledPressureMessage.cs" company="Patryk Mikulicz">
//  Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  The pressure readings for the typical setup of one absolute and differential pressure sensor. 
//  The units are as specified in each field.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The pressure readings for the typical setup of one absolute and differential pressure sensor.
    /// The units are as specified in each field.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ScaledPressureMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageIdOld Id => MessageIdOld.ScaledPressure;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets absolute pressure (hectopascal)
        /// </summary>
        public float PressAbs { get; set; }

        /// <summary>
        /// Gets or sets differential pressure 1 (hectopascal)
        /// </summary>
        public float PressDiff { get; set; }

        /// <summary>
        /// Gets or sets temperature measurement (0.01 degrees celsius)
        /// </summary>
        public short Temperature { get; set; }
    }
}