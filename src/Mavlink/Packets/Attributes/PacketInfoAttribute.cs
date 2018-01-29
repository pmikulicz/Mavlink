// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketInfoAttribute.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//   Specifies additional information about packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.Attributes
{
    /// <summary>
    /// Specifies additional information about packet
    /// </summary>
    internal sealed class PacketInfoAttribute : PacketAttribute
    {
        /// <summary>
        /// Gets or sets signature length
        /// </summary>
        public int SignatureLength { get; set; }

        /// <summary>
        /// Gets or sets cyclic redundancy check
        /// </summary>
        public int CrcLength { get; set; }

        /// <summary>
        /// Gets or sets max payload length
        /// </summary>
        public int MaxPayloadLength { get; set; }
    }
}