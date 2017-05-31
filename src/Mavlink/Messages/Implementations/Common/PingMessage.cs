// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PingMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   A ping message either requesting or responding to a ping. This allows to measure the system latencies, including serial port, radio modem and UDP connections
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// A ping message either requesting or responding to a ping.
    /// This allows to measure the system latencies, including serial port, radio modem and UDP connections
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PingMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.Ping;

        /// <summary>
        /// Gets or sets unix timestamp in microseconds or since system boot if smaller than MAVLink epoch (1.1.2009)
        /// </summary>
        public ulong TimeUSec { get; set; }

        /// <summary>
        /// Gets or sets ping sequence
        /// </summary>
        public uint Sequence { get; set; }

        /// <summary>
        /// Gets or sets target systsem. 0 represents request ping from all receiving systems,
        /// if greater than 0 message is a ping response and number is the system id of the requesting system
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets target systsem. 0 represenrs request ping from all receiving components,
        /// if greater than 0 message is a ping response and number is the system id of the requesting system
        /// </summary>
        public byte TargetComponent { get; set; }
    }
}