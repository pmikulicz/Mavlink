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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParamRequestListMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageIdOld Id => MessageIdOld.ParamRequestList;

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