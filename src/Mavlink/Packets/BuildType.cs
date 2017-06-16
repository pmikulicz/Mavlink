// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines packet build types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Defines packet build types
    /// </summary>
    internal enum BuildType
    {
        /// <summary>
        /// Build packet with
        /// </summary>
        WithCrc = 0,

        WithoutCrc = 1
    }
}