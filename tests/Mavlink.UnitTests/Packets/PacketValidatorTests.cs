using Mavlink.Packets;
using NUnit.Framework;
using System;

namespace Mavlink.UnitTests.Packets
{
    [TestFixture]
    internal class PacketValidatorTests

    {
        protected IPacketValidator PacketValidator;

        [SetUp]
        public void SetUp()
        {
            PacketValidator = new PacketValidator();
        }

        [TestFixture]
        public sealed class ValidateMethodTests : PacketValidatorTests
        {
            [Test]
            public void PacketValidReturnsTrue()
            {
                /*
                hdr len seq sys cmp id   payload (len 9)------------------  crc---
                0   1   2   3   4   5   6   7   8   9   a   b   c   d   e   f  10
                FE  09  4E  01  01  00  00  00  00  00  02  03  51  04  03  1C  7F
                 */
                Packet packet = new Packet(0x09, 0x4E, 0x01, 0x01, 0x00,
                    new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 }, new byte[] { 0x1C, 0x7F });

                bool result = PacketValidator.Validate(packet);

                Assert.AreEqual(true, result);
            }

            [Test]
            public void PacketInvalidReturnsFalse()
            {
                /*
                hdr len seq sys cmp id   payload (len 9)------------------  crc---
                0   1   2   3   4   5   6   7   8   9   a   b   c   d   e   f  10
                FE  09  4E  01  01  00  01  00  00  00  02  03  51  04  03  1C  7F
                 */
                Packet packet = new Packet(0x09, 0x4E, 0x01, 0x01, 0x00,
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 }, new byte[] { 0x1C, 0x7F });

                bool result = PacketValidator.Validate(packet);

                Assert.AreEqual(false, result);
            }

            [Test]
            public void PacketNullThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => PacketValidator.Validate(null));
            }
        }
    }
}