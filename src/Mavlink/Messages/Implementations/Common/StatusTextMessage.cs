// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusTextMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Status text message. WARNING: They consume quite some bandwidth, so use only for important status and error messages.
//   If implemented wisely, these messages are buffered on the MCU and sent only at a limited rate (e.g. 10 Hz).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Status text message. WARNING: They consume quite some bandwidth, so use only for important status and error messages.
    /// If implemented wisely, these messages are buffered on the MCU and sent only at a limited rate (e.g. 10 Hz).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StatusTextMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.StatusText;

        /// <summary>
        /// Gets or sets severity of status. Relies on the definitions within RFC-5424.
        /// See also <seealso cref="MavServerity"/>
        /// </summary>
        public MavServerity Severity { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        private char[] _text;

        /// <summary>
        /// Gets or sets status text message, without null termination character
        /// </summary>
        public char[] Text
        {
            get => _text;

            set => _text = value;
        }
    }
}