// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkVersion.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines all mavlink protocol versions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink
{
    /// <summary>
    /// Defines all mavlink protocol versions
    /// </summary>
    [Flags]
    public enum MavlinkVersion
    {
        /// <summary>
        /// Represents version v1.0, which was widely adopted around 2013
        /// </summary>
        V10,

        /// <summary>
        /// Represenrs version v2.0, which was adopted by major users early 2017
        /// </summary>
        V20
    }
}