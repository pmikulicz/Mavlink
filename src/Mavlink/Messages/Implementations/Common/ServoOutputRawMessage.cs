// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServoOutputRawMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The RAW values of the servo outputs (for RC input from the remote, use the RC_CHANNELS messages). 
//   The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The RAW values of the servo outputs (for RC input from the remote, use the RC_CHANNELS messages). 
    /// The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ServoOutputRawMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.ServoOutputRaw;

        /// <summary>
        /// Gets or sets first servo output value, in microseconds
        /// </summary>
        public uint TimeUsec { get; set; }

        /// <summary>
        /// Gets or sets first servo output value, in microseconds
        /// </summary>
        public ushort FirstServoRaw { get; set; }

        /// <summary>
        /// Gets or sets second servo output value, in microseconds
        /// </summary>
        public ushort SecondServoRaw { get; set; }

        /// <summary>
        /// Gets or sets third servo output value, in microseconds
        /// </summary>
        public ushort ThirdServoRaw { get; set; }

        /// <summary>
        /// Gets or sets fourth servo output value, in microseconds
        /// </summary>
        public ushort FourthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets sixth servo output value, in microseconds
        /// </summary>
        public ushort SixthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets seventh servo output value, in microseconds
        /// </summary>
        public ushort SeventhServoRaw { get; set; }

        /// <summary>
        /// Gets or sets eighth servo output value, in microseconds
        /// </summary>
        public ushort EighthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets ninth servo output value, in microseconds
        /// </summary>
        public ushort NinthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets tenth servo output value, in microseconds
        /// </summary>
        public ushort TenthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets eleventh servo output value, in microseconds
        /// </summary>
        public ushort EleventhServoRaw { get; set; }

        /// <summary>
        /// Gets or sets twelfth servo output value, in microseconds
        /// </summary>
        public ushort TwelfthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets thirteenth servo output value, in microseconds
        /// </summary>
        public ushort ThirteenthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets fourteenth servo output value, in microseconds
        /// </summary>
        public ushort FourteenthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets fifteenth servo output value, in microseconds
        /// </summary>
        public ushort FifteenthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets sixteenth servo output value, in microseconds
        /// </summary>
        public ushort SixteenthServoRaw { get; set; }

        /// <summary>
        /// Gets or sets servo output port (set of 8 outputs = 1 port). 
        /// Most MAVs will just use one, but this allows to encode more than 8 servos
        /// </summary>
        public byte Port { get; set; }


    }
}