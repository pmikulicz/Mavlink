// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketBuilder.cs" company="Raiffeisen Leasing Polska S.A.">
//   Copyright (c) 2018 Raiffeisen Leasing Polska S.A. All Rights Reserved.
// </copyright>
// <summary>
//   Abstract implementation of a component which is responsible for building mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Abstract implementation of a component which is responsible for building mavlink packet
    /// </summary>
    internal abstract class PacketBuilder : IPacketBuilder
    {
        private const int DefaultPacketLength = 50;
        private bool _metadataSetUp = false;
        protected readonly IPacketMetadataContext PacketMetadataConetxt;
        protected readonly List<byte> PacketBuffer = new List<byte>(DefaultPacketLength);
        protected readonly Packet PacketTemplate;

        protected PacketBuilder(IPacketMetadataContext packetMetadataConetxt, Packet packetTemplate)
        {
            PacketMetadataConetxt = packetMetadataConetxt ?? throw new ArgumentNullException(nameof(packetMetadataConetxt));
            PacketTemplate = packetTemplate;
        }

        /// <inheritdoc />
        public bool AddByte(byte packetByte)
        {
            if (packetByte == PacketTemplate.Header)
                InitializeProcess();

            PacketBuffer.Add(packetByte);

            return !(HasPacketMetadata(PacketBuffer) & IsPacketComplete(PacketBuffer));
        }

        /// <inheritdoc />
        public abstract Packet Build(BuildType buildType = BuildType.WithCrc);

        /// <inheritdoc />
        public abstract MavlinkVersion MavlinkVersion { get; }

        private bool IsPacketComplete(IReadOnlyCollection<byte> packetBytes)
        {
            return packetBytes.Count ==
                   PacketMetadataConetxt.MetadataLength + PacketTemplate.PayloadLength + PacketMetadataConetxt.CrCLength +
                   PacketMetadataConetxt.SignatureLength;
        }

        private bool HasPacketMetadata(IReadOnlyCollection<byte> packetBytes)
        {
            bool hasPacketMetadata = packetBytes.Count >= PacketMetadataConetxt.MetadataLength;

            if (hasPacketMetadata & !_metadataSetUp)
                SetMetadata();

            return hasPacketMetadata;
        }

        private void InitializeProcess()
        {
            _metadataSetUp = false;
            PacketBuffer.Clear();
        }

        private void SetMetadata()
        {
            Type packetType = PacketTemplate.GetType();

            foreach (var propertyInfo in packetType.GetProperties())
            {
                if (!PacketMetadataConetxt.HasDataIndex(propertyInfo)) continue;

                int dataIndex = PacketMetadataConetxt.GetDataIndex(propertyInfo);
                propertyInfo.SetValue(PacketTemplate, PacketBuffer[dataIndex]);
            }

            _metadataSetUp = true;
        }
    }
}