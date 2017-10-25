using Mavlink.Messages;
using Mavlink.Messages.Dialects.Ardupilot;
using Mavlink.Messages.Dialects.Common;
using Xunit;

namespace Mavlink.UnitTests.Messages
{
    public class MessageIdTests
    {
        public sealed class EqualsTests : MessageIdTests
        {
            [Fact]
            public void Equals_NullObject_ReturnFalse()
            {
                MessageId messageId = new CommonMessageId(CommonId.Heartbeat);
                bool result = messageId.Equals(null);

                Assert.False(result);
            }

            [Fact]
            public void Equals_TheSameObject_ReturnTrue()
            {
                var messageId = new CommonMessageId(CommonId.Heartbeat);
                var comparedMessageId = new CommonMessageId(CommonId.Heartbeat);

                var result = messageId.Equals(comparedMessageId);

                Assert.True(result);
            }

            [Fact]
            public void Equals_ObjectWithOtherType_ReturnFalse()
            {
                MessageId ardupilotMessageId = new ArdupilotMessageId(ArdupilotId.Heartbeat);
                MessageId commonMessageId = new CommonMessageId(CommonId.Heartbeat);

                var result = ardupilotMessageId.Equals(commonMessageId);

                Assert.False(result);
            }

            [Fact]
            public void Equals_ObjectWithOtherId_ReturnFalse()
            {
                MessageId messageId = new CommonMessageId(CommonId.Heartbeat);
                MessageId comparedMessageId = new CommonMessageId(CommonId.ParamRequestRead);

                bool result = messageId.Equals(comparedMessageId);

                Assert.False(result);
            }
        }

        public sealed class EqualsOperatorTests : MessageIdTests
        {
            [Fact]
            public void EqualsOperator_TwoNullObjects_ReturnTrue()
            {
                MessageId firstMessageId = null;
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId == secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void EqualsOperator_OneNullObject_ReturnFalse()
            {
                MessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId == secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void EqualsOperator_TheSameTwoObjects_ReturnTrue()
            {
                MessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                MessageId secondMessageId = new CommonMessageId(CommonId.Heartbeat);

                bool result = firstMessageId == secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void EqualsOperator_DifferentTwoObjects_ReturnFalse()
            {
                CommonMessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                CommonMessageId secondMessageId = new CommonMessageId(CommonId.ParamRequestRead);

                bool result = firstMessageId == secondMessageId;

                Assert.False(result);
            }
        }

        public sealed class NotEqualsOperatorTests : MessageIdTests
        {
            [Fact]
            public void NotEqualsOperator_TwoNullObjects_ReturnFalse()
            {
                MessageId firstMessageId = null;
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId != secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void NotEqualsOperator_OneNullObject_ReturnTrue()
            {
                MessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                MessageId secondMessageId = null;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                bool result = firstMessageId != secondMessageId;

                Assert.True(result);
            }

            [Fact]
            public void NotEqualsOperator_TheSameTwoObjects_ReturnFalse()
            {
                MessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                MessageId secondMessageId = new CommonMessageId(CommonId.Heartbeat);

                bool result = firstMessageId != secondMessageId;

                Assert.False(result);
            }

            [Fact]
            public void NotEqualsOperator_DifferentTwoObjects_ReturnTrue()
            {
                CommonMessageId firstMessageId = new CommonMessageId(CommonId.Heartbeat);
                CommonMessageId secondMessageId = new CommonMessageId(CommonId.ParamRequestRead);

                bool result = firstMessageId != secondMessageId;

                Assert.True(result);
            }
        }
    }
}