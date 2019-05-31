using RestEase.Implementation;
using System.Net.Http;

namespace NRuneScape.OldSchool.Net
{
    internal class OldSchoolRequster : Requester
    {
        private readonly OldSchoolJsonSerializer _jsonSerializer;

        public OldSchoolRequster(HttpClient httpClient, OldSchoolJsonSerializer jsonSerializer) : base(httpClient)
        {
            _jsonSerializer = jsonSerializer;

            ResponseDeserializer = new OldSchoolResponseDeserialzer(_jsonSerializer);
            RequestQueryParamSerializer = new OldSchoolQueryParamSerializer(_jsonSerializer);
        }
    }
}
