// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RcChannelsScaledMessage .cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   The scaled values of the RC channels received. (-100%) -10000, (0%) 0, (100%) 10000. 
//   Channels that are inactive should be set to UINT16_MAX
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// The scaled values of the RC channels received. (-100%) -10000, (0%) 0, (100%) 10000. 
    /// Channels that are inactive should be set to UINT16_MAX
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RcChannelsScaledMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.RcChannelsScaled;

        /// <summary>
        /// Gets or sets timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Gets or sets first RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 1 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short FirstChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets second RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 2 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short SecondChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets third RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 3 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short ThirdChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets fourth RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 4 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short FourthChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets fifth RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 5 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short FifthChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets sixth RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 6 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short SixthChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets seventh RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 7 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short SeventhChannelScaled { get; set; }

        /// <summary>
        /// Gets or sets eighth RC channel value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.	
        /// RC channel 8 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.
        /// </summary>
        public short EighthChannelScaled { get; set; }

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