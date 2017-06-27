// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RcChannelsRawMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The RAW values of the RC channels received. 
//   The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The RAW values of the RC channels received. 
    /// The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RcChannelsRawMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.RcChannelsRaw;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets first RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort FirstChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets second RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort SecondChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets third RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort ThirdChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets fourth RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort FourthChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets fifth RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort FifthChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets sixth RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort SixthChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets seventh RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort SeventhChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets eighth RC channel value, in microseconds. A value of UINT16_MAX implies the channel is unused
        /// </summary>
        public ushort EighthChannelRaw { get; set; }

        /// <summary>
        /// Gets or sets servo output port (set of 8 outputs = 1 port). 
        /// Most MAVs will just use one, but this allows for more than 8 servos
        /// </summary>
        public byte Port { get; set; }

        /// <summary>
        /// Gets or sets receive signal strength indicator, 0: 0%, 100: 100%, 255: invalid/unknown.
        /// </summary>
        public byte Rssi { get; set; }


    }
}