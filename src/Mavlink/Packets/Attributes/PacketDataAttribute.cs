// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketDataAttribute.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//  Specifies additional information about packet data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets.Attributes
{
    /// <summary>
    /// Specifies additional information about packet data
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal sealed class PacketDataAttribute : PacketAttribute
    {
        /// <summary>
        /// Gets or sets packet data position as an index in
        /// mavlink packet represented as byte array
        /// </summary>
        public int Index { get; set; }
    }
}