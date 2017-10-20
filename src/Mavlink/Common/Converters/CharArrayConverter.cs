namespace Mavlink.Common.Converters
{
    internal sealed class CharArrayConverter : ByteConverter<char[]>
    {
        protected override char[] RunConversion(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }
    }
}