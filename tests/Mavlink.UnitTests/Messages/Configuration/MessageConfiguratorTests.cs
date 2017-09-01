using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using NUnit.Framework;
using System;

namespace Mavlink.UnitTests.Messages.Configuration
{
    [TestFixture]
    internal class MessageConfiguratorTests
    {
        private static IMessageConfigurator _messageConfigurator;
        private static readonly Type HeartbeatMessageType = typeof(HeartbeatMessage);

        [TestFixture]
        internal sealed class SetNamesTests : MessageConfiguratorTests
        {
            [Test]
            public void SetName_NullString_ThrowArgumentNullException()
            {
                _messageConfigurator = new MessageConfigurator(new MessageDetails(HeartbeatMessageType));
                Assert.Throws<ArgumentNullException>(() => _messageConfigurator.SetName(null));
            }
        }
    }
}