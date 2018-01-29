// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Builder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for building single first version mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which is responsible for building the first version of the mavlink packet
    /// </summary>
    internal sealed class PacketV1Builder : PacketBuilder
    {
        public PacketV1Builder(IPacketMetadataContext packetMetadataConetxt)
            : base(packetMetadataConetxt, new PacketV1())
        {
        }

        /// <inheritdoc />
        public override Packet Build(BuildType buildType = BuildType.WithCrc)
        {
            Array.Copy(PacketBuffer.ToArray(), PacketMetadataConetxt.MetadataLength, PacketTemplate.Payload, 0,
                PacketTemplate.PayloadLength);

            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, PacketTemplate);
                memoryStream.Position = 0;

                return (PacketV1)formatter.Deserialize(memoryStream);
            }
        }

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion => MavlinkVersion.V10;
    }
}