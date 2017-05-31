// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissionRequestMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Request the information of the mission item with the sequence number seq.
//   The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;

namespace Mavlink.Messages.Implementations.Common
{
    /// <summary>
    /// Request the information of the mission item with the sequence number seq.
    /// The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol
    /// </summary>
    public struct MissionRequestMessage : ICommonMessage
    {
        /// <inheritdoc />
        public MessageId Id => MessageId.MissionRequest;
    }
}