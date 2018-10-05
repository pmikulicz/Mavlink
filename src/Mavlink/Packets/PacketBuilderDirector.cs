using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Mavlink.Packets
{
    internal sealed class PacketBuilderDirector : IPacketBuilderDirector
    {
        private readonly IPacketBuilderFactory _builderFactory;
        private readonly PacketStructure _packetStructure;
        private readonly ConcurrentBag<byte> _packetBuffer = new ConcurrentBag<byte>();

        public PacketBuilderDirector(IPacketBuilderFactory builderFactory, PacketStructure packetStructure)
        {
            _builderFactory = builderFactory ?? throw new ArgumentNullException(nameof(builderFactory));
            _packetStructure = packetStructure;
        }

        public bool AddByte(byte packetByte)
        {
            if (packetByte == _packetStructure.Header)
                return false;

            _packetBuffer.Add(packetByte);

            return true;
        }

        public IPacketBuilder Construct()
        {
            IPacketBuilder packetBuilder = _builderFactory.Create(
                new[] { _packetStructure.Header }.Concat(_packetBuffer).ToArray(),
                _packetStructure);
            _packetBuffer.Clear();

            return packetBuilder;
        }
    }
}