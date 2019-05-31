using System.Net.Http;
using RestEase;

namespace NRuneScape.GETracker
{
    internal class GETrackerRequester : ResponseDeserializer
    {
        private readonly GETrackerJsonSerializer _serializer;

        public GETrackerRequester(GETrackerJsonSerializer serializer) 
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
