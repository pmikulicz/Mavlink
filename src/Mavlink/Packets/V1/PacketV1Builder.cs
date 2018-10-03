// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Builder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for building single first version mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.V1
{
    /// <summary>
    /// Component which is responsible for building the first version of the mavlink packet
    /// </summary>
    internal sealed class PacketV1Builder : IPacketBuilder
    {
        private readonly byte[] _content;

        public PacketV1Builder(byte[] content)
        {
            _content = content;
        }

        /// <inheritdoc />
        public Packet Build(BuildType buildType = BuildType.WithCrc)
        {
            return null;
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}