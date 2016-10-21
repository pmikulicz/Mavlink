// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavParamType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines the datatype of a MAVLink parameter
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Implementations.Common.Types
{
    /// <summary>
    /// Defines the datatype of a MAVLink parameter
    /// </summary>
    public enum MavParamType : byte
    {
        /// <summary>
        /// 8-bit unsigned integer
        /// </summary>
        Uint8 = 1,

        /// <summary>
        /// 8-bit signed integer
        /// </summary>
        Int8 = 2,

        /// <summary>
        /// 16-bit unsigned integer
        /// </summary>
        Uint16 = 3,

        /// <summary>
        /// 16-bit signed integer
        /// </summary>
        Int16 = 4,

        /// <summary>
        /// 32-bit unsigned integer
        /// </summary>
        Uint32 = 5,

        /// <summary>
        /// 32-bit signed integer
        /// </summary>
        Int32 = 6,

        /// <summary>
        /// 64-bit unsigned integer
        /// </summary>
        Uint64 = 7,

        /// <summary>
        /// 64-bit signed integer
        /// </summary>
        Int64 = 8,

        /// <summary>
        /// 32-bit floating-point
        /// </summary>
        Real32 = 9,

        /// <summary>
        /// 64-bit floating-point
        /// </summary>

        Real64 = 10
    }
}