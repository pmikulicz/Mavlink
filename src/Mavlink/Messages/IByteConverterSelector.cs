using Mavlink.Common.Converters;
using System;

namespace Mavlink.Messages
{
    internal interface IByteConverterSelector
    {
        IByteConverter Select(Type dedicatedType);
    }
}