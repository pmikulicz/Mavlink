// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkEngineFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory for creating engine for the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Packets;

namespace Mavlink
{
    /// <summary>
    /// Factory for creating engine for the mavlink protocol
    /// </summary>
    internal sealed class MavlinkEngineFactory : IMavlinkEngineFactory
    {
        /// <inheritdoc />
        public IMavlinkEngine<TMessage> Create<TMessage>() where TMessage : MavlinkMessage
        {
            return new MavlinkEngine<TMessage>(new PacketHandler(), new MessageFactory<TMessage>(new MessageMetadataContainerFactory(), null));
        }
    }
}