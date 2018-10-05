// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents component which gives blueprint of packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common;
using System.Collections.Generic;
using System.Linq;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents component which gives blueprint of packet
    /// </summary>
    internal sealed class PacketBlueprint : IPacketBlueprint
    {
        private static readonly IDictionary<MavlinkVersion, PacketDefinition> PacketsDefinition;
        private static readonly IDictionary<MavlinkVersion, PacketStructure> PacketsStructure;
        private static readonly IInstanceCreator InstanceCreator = new InstanceCreator();

        static PacketBlueprint()
        {
            PacketsDefinition = InitializePacketsDefinition();
            PacketsStructure = InitializePacketsStructure();
        }

        /// <inheritdoc />
        public PacketDefinition GetPacketDefinition(MavlinkVersion mavlinkVersion)
        {
            if (!PacketsDefinition.ContainsKey(mavlinkVersion))
                throw new MavlinkException(
                    $"Cannot ger packet definition for mavlink version {mavlinkVersion}");

            return PacketsDefinition[mavlinkVersion];
        }

        /// <inheritdoc />
        public PacketStructure GetPacketStructrure(MavlinkVersion mavlinkVersion)
        {
            if (!PacketsStructure.ContainsKey(mavlinkVersion))
                throw new MavlinkException(
                    $"Cannot ger packet structure for mavlink version {mavlinkVersion}");

            return PacketsStructure[mavlinkVersion];
        }

        private static IDictionary<MavlinkVersion, PacketStructure> InitializePacketsStructure()
        {
            IEnumerable<PacketStructure> packetsStructure = InstanceCreator.CreateDerived<PacketStructure>();

            return packetsStructure.ToDictionary(ps => ps.MavlinkVersion, ps => ps);
        }

        private static IDictionary<MavlinkVersion, PacketDefinition> InitializePacketsDefinition()
        {
            IEnumerable<PacketDefinition> packetsDefinition = InstanceCreator.CreateDerived<PacketDefinition>();

            return packetsDefinition.ToDictionary(pd => pd.MavlinkVersion, pd => pd);
        }
    }
}