// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamValueMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Emit the value of a onboard parameter.
//   The inclusion of param_count and param_index in the message allows the recipient to keep track of received parameters and
//   allows him to re-request missing parameters after a loss or timeout.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Emit the value of a onboard parameter.
    //  The inclusion of param_count and param_index in the message allows the recipient to keep track of received parameters and
    //  allows him to re-request missing parameters after a loss or timeout.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParamValueMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ParamValue;

        /// <summary>
        /// Gets or sets onboard parameter value
        /// </summary>
        public float ParamValue { get; set; }

        /// <summary>
        /// Gets or sets total number of onboard parameters
        /// </summary>
        public ushort ParamCount { get; set; }

        /// <summary>
        /// Gets or sets index of this onboard parameter
        /// </summary>
        public ushort ParamIndex { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private char[] paramId;

        /// <summary>
        /// Gets or sets onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and
        /// without null termination (NULL) byte if the length is exactly 16 chars.
        /// Applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        public char[] ParamId
        {
            get { return paramId; }

            set { paramId = value; }
        }

        /// <summary>
        /// Gets or sets onboard parameter type. See also <seealso cref="MavParamType"/>
        /// </summary>

        public MavParamType ParamType { get; set; }
    }
}