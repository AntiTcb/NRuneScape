using System.Buffers;
using Voltaic.Serialization;
using Voltaic.Serialization.Json;

namespace NRuneScape.GETracker
{
    public class GETrackerJsonSerializer : JsonSerializer
    {
        public GETrackerJsonSerializer(ConverterCollection converters = null, ArrayPool<byte> bytePool = null) 
            : base(converters, bytePool)
        {
            _converters.SetGenericDefault(typeof(DataWrapper<>), typeof(DataWrapperConverter<>), (t) => t.GenericTypeArguments[0]);
        }
    }
}
