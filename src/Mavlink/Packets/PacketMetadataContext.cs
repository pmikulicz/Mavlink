// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketMetadataContext.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//   Component which represenst packet metadata context
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mavlink.Packets.Attributes;

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which represenst packet metadata context
    /// </summary>
    internal sealed class PacketMetadataContext : IPacketMetadataContext
    {
        private readonly MavlinkVersion _mavlinkVersion;
        private readonly IDictionary<PropertyInfo, int> _metadataCache = new Dictionary<PropertyInfo, int>(10);

        public PacketMetadataContext(MavlinkVersion mavlinkVersion)
        {
            _mavlinkVersion = mavlinkVersion;
            InitializeMedatada();
        }

        /// <inheritdoc />
        public int MetadataLength => _metadataCache.Count;

        /// <inheritdoc />
        public int CrCLength { get; private set; }

        /// <inheritdoc />
        public int MaxPayloadLength { get; private set; }

        /// <inheritdoc />
        public int SignatureLength { get; private set; }

        /// <inheritdoc />
        public int GetDataIndex(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var baseProperty = GetBaseProperty(property);

            if (HasDataIndex(baseProperty))
                return _metadataCache[baseProperty];

            throw new InvalidOperationException($"Packet property {property.Name} has no metadata information");
        }

        /// <inheritdoc />
        public bool HasDataIndex(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var baseProperty = GetBaseProperty(property);

            return _metadataCache.ContainsKey(baseProperty);
        }

        private static PropertyInfo GetBaseProperty(PropertyInfo property)
        {
            Type type = property.ReflectedType;

            while (type.BaseType != typeof(object))
            {
                type = type.BaseType;
            }

            var baseProperty = type.GetProperty(property.Name);

            return baseProperty ?? property;
        }

        private void InitializeMedatada()
        {
            IEnumerable<Type> packetTypes = Assembly
                .GetAssembly(typeof(Packet))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Packet)) | t == typeof(Packet));

            foreach (var packetType in packetTypes)
            {
                var properties = packetType.GetProperties();

                foreach (var propertyInfo in properties)
                    GetPacketData(propertyInfo, packetType);

                GetPacketInformation(packetType);
            }
        }

        private void GetPacketData(PropertyInfo propertyInfo, Type packetType)
        {
            var attributes = propertyInfo.GetCustomAttributes<PacketDataAttribute>().ToList();

            if (!attributes.Any())
                return;

            var attribute = attributes.FirstOrDefault(MatchMavlinkVersion);

            if (attribute == null)
                throw new InvalidOperationException(
                    $"There is no information for property '{propertyInfo.Name}' and type '{packetType}' about packet metadata for mavlink version {_mavlinkVersion}");

            _metadataCache.Add(propertyInfo, attribute.Index);
        }

        private void GetPacketInformation(Type packetType)
        {
            PacketInfoAttribute packetInfoAttribute = packetType.GetCustomAttribute<PacketInfoAttribute>();

            if (packetInfoAttribute?.MavlinkVersion != _mavlinkVersion)
                return;

            CrCLength = packetInfoAttribute.CrcLength;
            SignatureLength = packetInfoAttribute.SignatureLength;
            MaxPayloadLength = packetInfoAttribute.MaxPayloadLength;
        }

        private bool MatchMavlinkVersion(PacketDataAttribute attribute)
        {
            return attribute.MavlinkVersion.HasFlag(_mavlinkVersion);
        }
    }
}