namespace Mavlink.UnitTests
{
    public static class Utils
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