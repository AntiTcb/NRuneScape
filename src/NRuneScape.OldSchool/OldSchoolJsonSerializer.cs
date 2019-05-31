using System.Buffers;
using Voltaic.Serialization;
using Voltaic.Serialization.Json;

namespace NRuneScape.OldSchool
{
    public class OldSchoolJsonSerializer : JsonSerializer
    {
        public OldSchoolJsonSerializer(ConverterCollection converters = null, ArrayPool<byte> bytePool = null) : base(converters, bytePool)
        {

        }
    }
}
