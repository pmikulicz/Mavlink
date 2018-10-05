// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkEngineFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory for creating engine for the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common;
using Mavlink.Common.Converters;
using Mavlink.Messages;
using Mavlink.Packets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mavlink
{
    /// <summary>
    /// Factory for creating engine for the mavlink protocol
    /// </summary>
    internal sealed class MavlinkEngineFactory : IMavlinkEngineFactory
    {
        private static IEnumerable<IConverter> _cachedByteConverters;
        private readonly IPacketBuilderFactory _packetBuilderFactory;
        private readonly PacketStructure _packetStructure;

        public MavlinkEngineFactory(IPacketBuilderFactory packetBuilderFactory, PacketStructure packetStructure)
        {
            _packetBuilderFactory = packetBuilderFactory ?? throw new ArgumentNullException(nameof(packetBuilderFactory));
            _packetStructure = packetStructure ?? throw new ArgumentNullException(nameof(packetStructure));

            if (_cachedByteConverters == null)
                InitializeByteConverters();
        }

        private static void InitializeByteConverters()
        {
            var instanceCreator = new InstanceCreator();
            _cachedByteConverters = instanceCreator.CreateDerived<IConverter>();
        }

        /// <inheritdoc />
        public IMavlinkEngine<TMessage> Create<TMessage>(MavlinkVersion mavlinkVersion) where TMessage : IMavlinkMessage
        {
            return new MavlinkEngine<TMessage>(
                new MessageProcessor<TMessage>(
                    type =>
                    {
                        return _cachedByteConverters.FirstOrDefault(c => c.Type == type);
                    }), new PacketBuilderDirector(_packetBuilderFactory, _packetStructure));
        }
    }
}