using System.Collections.Generic;
using RestEase;

namespace NRuneScape.OldSchool.Net
{
    internal class OldSchoolQueryParamSerializer : RequestQueryParamSerializer
    {
        private readonly OldSchoolJsonSerializer _jsonSerializer;

        public OldSchoolQueryParamSerializer(OldSchoolJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public override IEnumerable<KeyValuePair<string, string>> SerializeQueryParam<T>(string name, T value, RequestQueryParamSerializerInfo info)
        {
            if (value == default)
                yield break;

            yield return new KeyValuePair<string, string>(name, _jsonSerializer.WriteUtf16String(value));
        }

        public override IEnumerable<KeyValuePair<string, string>> SerializeQueryCollectionParam<T>(string name, IEnumerable<T> values, RequestQueryParamSerializerInfo info)
        {
            if (values is null)
                yield break;
            
            foreach (var value in values)
            {
                if (value == default)
                    continue;

                yield return new KeyValuePair<string, string>(name, _jsonSerializer.WriteUtf16String(value));
            }
        }
    }
}