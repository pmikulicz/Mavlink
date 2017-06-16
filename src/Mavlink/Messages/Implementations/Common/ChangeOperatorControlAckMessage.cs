// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeOperatorControlAckMessage .cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Accept or deny control of this MAV
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Accept or deny control of this MAV
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChangeOperatorControlAckMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ChangeOperatorControlAck;

        /// <summary>
        /// Gets or sets id of the GCS
        /// </summary>
        public byte GcsSystemId { get; set; }

        /// <summary>
        /// Gets or sets control request. 0 represenrs request control of this MAV and
        /// 1 represents release control of this MAV
        /// </summary>
        public byte ControlRequest { get; set; }

        /// <summary>
        /// Gets or sets acknowledge. 0 represents ACK, 1 represents NACK which is wrong passkey,
        /// 2 which is unsupported passkey encryption method and 3 which is already under control
        /// </summary>

        public byte Acknowledge { get; set; }
    }
}