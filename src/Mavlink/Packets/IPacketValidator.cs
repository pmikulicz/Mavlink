// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketValidator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsoble for validating packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which is responsoble for validating packet
    /// </summary>
    internal interface IPacketValidator
    {
        /// <summary>
        /// Validates packet performing cyclic redundancy check
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        bool Validate(Packet packet);

        /// <summary>
        /// Gets packet cyclic redundancy check value
        /// </summary>
        /// <param name="packet">Packet for which redundancy check value is created</param>
        /// <returns>Cyclic redundancy check</returns>
        byte[] GetChecksum(Packet packet);
    }
}