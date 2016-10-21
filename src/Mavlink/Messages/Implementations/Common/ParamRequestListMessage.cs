// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamRequestListMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request all parameters of this component. After this request, all parameters are emitted
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System.Runtime.InteropServices;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request all parameters of this component. After this request, all parameters are emitted
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ParamRequestListMessage : ICommonMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public MessageId Id => MessageId.ParamRequestList;

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte ComponentId { get; set; }
    }
}