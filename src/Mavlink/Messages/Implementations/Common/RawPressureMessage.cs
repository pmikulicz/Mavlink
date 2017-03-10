// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RawPressureMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The RAW pressure readings for the typical setup of one absolute pressure and one differential pressure sensor.
//   The sensor values should be the raw, UNSCALED ADC values
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The RAW pressure readings for the typical setup of one absolute pressure and one differential pressure sensor.
    /// The sensor values should be the raw, UNSCALED ADC values
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawPressureMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.RawPressure;

        /// <summary>
        /// Gets or sets timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        public ulong TimeUsec { get; set; }

        /// <summary>
        /// Gets or sets absolute pressure (raw)
        /// </summary>
        public short PressAbs { get; set; }

        /// <summary>
        /// Gets or sets differential pressure 1 (raw, 0 if nonexistant)
        /// </summary>
        public short FirstPressDiff { get; set; }

        /// <summary>
        /// Gets or sets differential pressure 2 (raw, 0 if nonexistant)
        /// </summary>
        public short SecondPressDiff { get; set; }

        /// <summary>
        /// Gets or sets raw Temperature measurement (raw)
        /// </summary>
        public short Temperature { get; set; }
    }
}