// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicatorFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for creating new instance of mavlink communicator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common;
using Mavlink.Connection;
using Mavlink.Messages;
using Mavlink.Packets;
using System.Collections.Generic;
using System.Linq;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for creating new instance of mavlink communicator
    /// </summary>
    public sealed class MavlinkCommunicatorFactory : IMavlinkCommunicatorFactory
    {
        private static IEnumerable<IPacketBuilderFactory> _cachedBuilderFactories;

        static MavlinkCommunicatorFactory()
        {
            InitializeBuilderFactories();
        }

        /// <inheritdoc />
        public IMavlinkCommunicator<TMessage> Create<TMessage>(IConnectionService connectionService, MavlinkVersion mavlinkVersion) where TMessage : IMavlinkMessage
        {
            var packetBuilderFactory = _cachedBuilderFactories.FirstOrDefault(f => f.MavlinkVersion == mavlinkVersion);

            if (packetBuilderFactory == null)
                throw new MavlinkException($"Cannot get packet builder factory for mavlink version {mavlinkVersion}");

            var packetBlueprint = new PacketBlueprint();
            var packetStructure = packetBlueprint.GetPacketStructrure(mavlinkVersion);
            return new MavlinkCommunicator<TMessage>(connectionService, mavlinkVersion, new MavlinkEngineFactory(packetBuilderFactory, packetStructure));
        }

        private static void InitializeBuilderFactories()
        {
            var instanceCreator = new InstanceCreator();
            _cachedBuilderFactories = instanceCreator.CreateDerived<IPacketBuilderFactory>();
        }
    }
}