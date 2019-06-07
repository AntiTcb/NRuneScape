using System;
using System.Net;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class ApiHash
    {
        [ModelProperty("uuid")]
        public string Id { get; set; }
        [ModelProperty("hash")]
        public string Hash { get; set; }
        [ModelProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; }
        [ModelProperty("responseTime")]
        public float responseTime { get; set; }
        [ModelProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
