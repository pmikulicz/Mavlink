// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketBuilder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for building single mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which is responsible for building single mavlink packet
    /// </summary>
    internal interface IPacketBuilder
    {
        /// <summary>
        /// Add single packet byte
        /// </summary>
        /// <param name="packetByte">Single packet byte</param>
        /// <returns>value indicating whether all packet bytes were collected and are ready to build</returns>
        bool AddByte(byte packetByte);

        //        /// <summary>
        //        /// Add array of packet bytes
        //        /// </summary>
        //        /// <param name="packetBytes">Array of packet bytes</param>
        //        /// <returns>value indicating whether all packet bytes were collected and are ready to build</returns>
        //        bool AddBytes(byte[] packetBytes);

        /// <summary>
        /// Builds mavlink packet from aggregated bytes
        /// </summary>
        /// <param name="buildType">
        /// Type of a build.
        /// Builder can build packet with crc or without crc
        /// </param>
        /// <returns>
        /// New packet from aggregated bytes.
        /// If packet is not valid it returns null
        /// </returns>
        Packet Build(BuildType buildType = BuildType.WithCrc);
    }
}