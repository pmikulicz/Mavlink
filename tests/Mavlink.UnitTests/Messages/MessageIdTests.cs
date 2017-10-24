using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Xunit;

namespace Mavlink.UnitTests.Messages
{
    public class MessageIdTests
    {
        public sealed class EqualsTests : MessageIdTests
        {
            [Fact]
            public void Equals_NullObject_ReturnsFalse()
            {
                MessageId messageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                bool result = messageId.Equals(null);

                Assert.False(result);
            }

            [Fact]
            public void Equals_TheSameObject_ReturnsTrue()
            {
                var messageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                var comparedMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);

                var result = messageId.Equals(comparedMessageId);

                Assert.True(result);
            }

            [Fact]
            public void Equals_ObjectWithOtherType_ReturnsFalse()
            {
                //                var messageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                //                var comparedMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                //
                //                var result = messageId.Equals(comparedMessageId);
                //                var expectedResult = true;
                //
                //                Assert.Equal(expectedResult, result);
            }

            [Fact]
            public void Equals_ObjectWithOtherId_ReturnsTrue()
            {
                MessageId messageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId comparedMessageId = new ArdupilotMessageId(ArdupilotId.ParamRequestRead);

                bool result = messageId.Equals(comparedMessageId);

                Assert.True(result);
            }
        }

        public sealed class EqualsOperatorTests : MessageIdTests
        {
            [Fact]
            public void EqualsOperator_TwoNullObjects_ReturnsTrue()
            {
                MessageId firstMessageId = null;
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId == secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void EqualsOperator_OneNullObject_ReturnsFalse()
            {
                MessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId == secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void EqualsOperator_TheSameTwoObjects_ReturnsTrue()
            {
                MessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId secondMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);

                bool result = firstMessageId == secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void EqualsOperator_DifferentTwoObjects_ReturnsFalse()
            {
                ArdupilotMessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                ArdupilotMessageId secondMessageId = new ArdupilotMessageId(ArdupilotId.ParamRequestRead);

                bool result = firstMessageId == secondMessageId;

                Assert.False(result);
            }
        }

        public sealed class NotEqualsOperatorTests : MessageIdTests
        {
            [Fact]
            public void NotEqualsOperator_TwoNullObjects_ReturnsFalse()
            {
                MessageId firstMessageId = null;
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId != secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void NotEqualsOperator_OneNullObject_ReturnsTrue()
            {
                MessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId != secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void NotEqualsOperator_TheSameTwoObjects_ReturnsFalse()
            {
                MessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId secondMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);

                bool result = firstMessageId != secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void NotEqualsOperator_DifferentTwoObjects_ReturnsTrue()
            {
                ArdupilotMessageId firstMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                ArdupilotMessageId secondMessageId = new ArdupilotMessageId(ArdupilotId.ParamRequestRead);

                bool result = firstMessageId != secondMessageId;

                Assert.True(result);
            }
        }
    }
}