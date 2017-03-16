﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamRequestReadMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request to read the onboard parameter with the param_id string id.
//   Onboard parameters are stored as key[const char*] -> value[float].
//   This allows to send a parameter to any other component (such as the GCS) without the need of previous knowledge of possible parameter names.
//   Thus the same GCS can store different parameters for different autopilots.
//   See also http://qgroundcontrol.org/parameter_interface for a full documentation of QGroundControl and IMU code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    ///  Request to read the onboard parameter with the param_id string id.
    //   Onboard parameters are stored as key[const char*] -> value[float].
    //   This allows to send a parameter to any other component (such as the GCS) without the need of previous knowledge of possible parameter names.
    //   Thus the same GCS can store different parameters for different autopilots.
    //   See also http://qgroundcontrol.org/parameter_interface for a full documentation of QGroundControl and IMU code.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParamRequestReadMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ParamRequestRead;

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private char[] paramId;

        /// <summary>
        /// Gets or sets onboard parameter id, terminated by NULL.
        /// If the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte
        /// if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        public char[] ParamId
        {
            get { return paramId; }

            set { paramId = value; }
        }

        /// <summary>
        /// Gets or sets parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)
        /// </summary>
        public short ParamIndex { get; set; }
    }
}