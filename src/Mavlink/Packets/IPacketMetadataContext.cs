// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//   Interface of a component which represenst packet metadata context
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which represenst packet metadata context
    /// </summary>
    internal interface IPacketMetadataContext
    {
        /// <summary>
        /// Gets total length of packet metadata
        /// </summary>
        int MetadataLength { get; }

        /// <summary>
        /// Gets cyclic redundancy check
        /// </summary>
        int CrCLength { get; }

        /// <summary>
        /// Gets max payload length
        /// </summary>
        int MaxPayloadLength { get; }

        /// <summary>
        /// Gets signature length
        /// </summary>
        int SignatureLength { get; }

        /// <summary>
        /// Gets packet data position as an index in
        /// mavlink packet represented as byte array
        /// </summary>
        /// <param name="property">Data as property information</param>
        /// <returns>Position as an index in mavlink packet</returns>
        int GetDataIndex(PropertyInfo property);

        /// <summary>
        /// Indicates whether packet property has
        /// metadata with index
        /// </summary>
        /// <param name="property">Data as property information</param>
        /// <returns>Value indicating whether packet property has metadata with index</returns>
        bool HasDataIndex(PropertyInfo property);
    }
}