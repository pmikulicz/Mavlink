// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeOperatorControlMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request to control this MAV
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request to control this MAV
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ChangeOperatorControlMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ChangeOperatorControl;

        /// <summary>
        /// Gets or sets system the GCS requests control for
        /// </summary>

        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets control request. 0 represents request control of this MAV
        /// and 1 represents release control of this MAV
        /// </summary>
        public byte ControlRequest { get; set; }

        /// <summary>
        /// Gets or sets version. 0 represents key as plaintext,
        /// 1-255 are reserved for future, different hashing/encryption variants.
        /// The GCS should in general use the safest mode possible initially and then gradually
        /// move down the encryption level if it gets a NACK message indicating an encryption mismatch
        /// </summary>
        public byte Version { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        private char[] passkey;

        /// <summary>
        /// Gets or sets password or key. Password or key, depending on version plaintext or encrypted.
        /// 25 or less characters, NULL terminated. The characters may involve A-Z, a-z, 0-9, and "!?,.-"
        /// </summary>
        public char[] Passkey
        {
            get { return passkey; }

            set { passkey = value; }
        }
    }
}