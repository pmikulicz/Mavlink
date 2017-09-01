// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionRequestListMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request the overall list of mission items from the system/component
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request the overall list of mission items from the system/component
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MissionRequestListMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionRequestList;

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }

        /// <summary>
        /// Gets or sets mission type. See also <seealso cref="MavMissionType"/>
        /// </summary>
        public MavMissionType MissionType { get; set; }
    }
}