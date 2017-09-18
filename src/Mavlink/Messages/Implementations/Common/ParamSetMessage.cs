// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamSetMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Set a parameter value TEMPORARILY to RAM. It will be reset to default on system reboot.
//   Send the ACTION MAV_ACTION_STORAGE_WRITE to PERMANENTLY write the RAM contents to EEPROM.
//   Iimportant is that receiving component should acknowledge the new parameter value by sending a param_value message to all communication partners.
//   This will also ensure that multiple GCS all have an up-to-date list of all parameters.
//   If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Set a parameter value TEMPORARILY to RAM. It will be reset to default on system reboot.
    /// Send the ACTION MAV_ACTION_STORAGE_WRITE to PERMANENTLY write the RAM contents to EEPROM.
    /// Iimportant is that receiving component should acknowledge the new parameter value by sending a param_value message to all communication partners.
    /// This will also ensure that multiple GCS all have an up-to-date list of all parameters.
    /// If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParamSetMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.ParamSet;

        /// <summary>
        /// Gets or sets onboard parameter value
        /// </summary>
        public float ParamValue { get; set; }

        /// <summary>
        /// Gets or sets target system
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets target component
        /// </summary>
        public byte TargetComponent { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private char[] paramId;

        /// <summary>
        /// Gets or sets onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and
        /// without null termination (NULL) byte if the length is exactly 16 chars.
        /// Applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        public char[] ParamId
        {
            get => paramId;

            set => paramId = value;
        }

        /// <summary>
        /// Gets or sets onboard parameter type. See also <seealso cref="MavParamType"/>
        /// </summary>
        public MavParamType ParamType { get; set; }
    }
}