using RestEase;
using System.Net.Http;

namespace NRuneScape.OldSchool.Net
{
    internal class OldSchoolResponseDeserialzer : ResponseDeserializer
    {
        private readonly OldSchoolJsonSerializer _jsonSerializer;

        public OldSchoolResponseDeserialzer(OldSchoolJsonSerializer jsonSerializer) 
            => _jsonSerializer = jsonSerializer;

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
            => _jsonSerializer.ReadUtf16<T>(content);
    }
}