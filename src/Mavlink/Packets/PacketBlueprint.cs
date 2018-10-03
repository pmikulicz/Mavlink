// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents component which gives blueprint of packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mavlink.Common.Converters;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents component which gives blueprint of packet
    /// </summary>
    internal sealed class PacketBlueprint : IPacketBlueprint
    {
        private static readonly IDictionary<MavlinkVersion, PacketDefinition> PacketsDefinition;
        private static readonly IDictionary<MavlinkVersion, PacketStructure> PacketsStructure;

        static PacketBlueprint()
        {
            PacketsDefinition = InitializePacketsDefinition();
            PacketsStructure = InitializePacketsStructure();
        }

        /// <inheritdoc />
        public PacketDefinition GetPacketDefinition(MavlinkVersion mavlinkVersion)
        {
            if (!PacketsDefinition.ContainsKey(mavlinkVersion))
                throw new InvalidOperationException(
                    $"Cannot ger packet definition for mavlink version {mavlinkVersion}");

            return PacketsDefinition[mavlinkVersion];
        }

        /// <inheritdoc />
        public PacketStructure GetPacketStructrure(MavlinkVersion mavlinkVersion)
        {
            if (!PacketsStructure.ContainsKey(mavlinkVersion))
                throw new InvalidOperationException(
                    $"Cannot ger packet structure for mavlink version {mavlinkVersion}");

            return PacketsStructure[mavlinkVersion];
        }

        private static IDictionary<MavlinkVersion, PacketStructure> InitializePacketsStructure()
        {
            IEnumerable<PacketStructure> packetsStructure = InitializeDerivedTypes<PacketStructure>();

            return packetsStructure.ToDictionary(ps => ps.MavlinkVersion, ps => ps);
        }

        private static IDictionary<MavlinkVersion, PacketDefinition> InitializePacketsDefinition()
        {
            IEnumerable<PacketDefinition> packetsDefinition = InitializeDerivedTypes<PacketDefinition>();

            return packetsDefinition.ToDictionary(ps => ps.MavlinkVersion, ps => ps);
        }

        private static IEnumerable<TBaseType> InitializeDerivedTypes<TBaseType>()
        {
            Type baseClass = typeof(TBaseType);
            Assembly assembly = Assembly.GetAssembly(baseClass);
            IEnumerable<Type> allTypes = assembly.GetTypes()
                .Where(t =>
                    !t.IsAbstract &&
                    !t.IsInterface &&
                    t.IsClass &&
                    baseClass.IsAssignableFrom(t));

            foreach (Type type in allTypes)
            {
                yield return (TBaseType)Activator.CreateInstance(type);
            }
        }
    }
}