// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkException.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents general mavlink exception
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace Mavlink
{
    /// <summary>
    /// Represents general mavlink exception
    /// </summary>
    [Serializable]
    public class MavlinkException : Exception
    {
        public MavlinkException()
        {
        }

        public MavlinkException(string message) : base(message)
        {
        }

        public MavlinkException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MavlinkException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}