namespace Mavlink.Messages.Dialects.Common
{
    public sealed class CommonMessageId : MessageId
    {
        public CommonMessageId(CommonId commonId) : base((int)commonId)
        {
            CommonId = commonId;
        }

        public CommonId CommonId { get; }
    }
}