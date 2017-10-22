namespace Mavlink.UnitTests.Common.Converters
{
    public static class Helpers
    {
        public static byte[] CreateByteArray(byte byteToFill, int arraySize)
        {
            var byteArray = new byte[arraySize]
                ;
            for (int i = 0; i < arraySize; i++)
            {
                byteArray[i] = byteToFill;
            }

            return byteArray;
        }
    }
}