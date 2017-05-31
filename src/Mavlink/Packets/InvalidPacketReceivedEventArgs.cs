using System;

namespace Mavlink.Packets
{
    internal sealed class InvalidPacketReceivedEventArgs
    {
        public InvalidPacketReceivedEventArgs(byte[] paketBytes)
        {
            if (paketBytes == null)
                throw new ArgumentNullException(nameof(paketBytes));

            PaketBytes = paketBytes;
        }

        public byte[] PaketBytes { get; }
    }
}