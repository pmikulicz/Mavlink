// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthKeyMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Emit an encrypted signature/ key identifying this system.
//   This protocol has been kept simple, so transmitting the key requires an encrypted channel for true safety
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Emit an encrypted signature/ key identifying this system.
    /// This protocol has been kept simple, so transmitting the key requires an encrypted channel for true safety
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AuthKeyMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.AuthKey;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private char[] key;

        /// <summary>
        /// Gets or sets authentication key
        /// </summary>

        public char[] Key
        {
            get => key;

            set => key = value;
        }
    }
}