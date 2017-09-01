// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionClearAllMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Delete all mission items at once
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Delete all mission items at once
    /// </summary>
    public struct MissionClearAllMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionClearAll;

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