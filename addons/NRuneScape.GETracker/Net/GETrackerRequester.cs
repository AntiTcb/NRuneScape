using System.Net.Http;
using RestEase;
using RestEase.Implementation;

namespace NRuneScape.GETracker
{
    internal class GETrackerRequester : Requester
    {
        private readonly GETrackerJsonSerializer _serializer;

        public GETrackerRequester(HttpClient httpClient, GETrackerJsonSerializer serializer)
            : base(httpClient)
        {
            _serializer = serializer;

            ResponseDeserializer = new GETrackerResponseDeserializer(_serializer);
        }
    }

    internal class GETrackerResponseDeserializer : ResponseDeserializer
    {
        private readonly GETrackerJsonSerializer _serializer;

        public GETrackerResponseDeserializer(GETrackerJsonSerializer serializer) 
            => _serializer = serializer;

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (content.Contains("\"data\":"))
                return _serializer.ReadUtf16<DataWrapper<T>>(content).Data;
            else
                return _serializer.ReadUtf16<T>(content);
        }
    }
}
