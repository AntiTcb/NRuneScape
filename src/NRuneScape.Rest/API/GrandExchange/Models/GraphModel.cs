using System.Collections.Generic;
using Newtonsoft.Json;

namespace NRuneScape.API
{
    internal class GraphModel
    {
        [JsonProperty("average")]
        public Dictionary<string, double> Average { get; set; }

        [JsonProperty("daily")]
        public Dictionary<string, double> Daily { get; set; }
    }
}
