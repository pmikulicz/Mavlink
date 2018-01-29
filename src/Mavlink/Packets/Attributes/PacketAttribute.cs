// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketAttribute.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//   Specifies base information about packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets.Attributes
{
    /// <summary>
    /// Specifies base information about packet
    /// </summary>
    internal abstract class PacketAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets mavlink version for which packet data is dedicated
        /// </summary>
        public MavlinkVersion MavlinkVersion { get; set; }
    }
}