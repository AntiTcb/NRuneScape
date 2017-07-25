using Newtonsoft.Json;

namespace NRuneScape.API
{
    internal class RuneDateModel
    {
        [JsonProperty("lastConfigUpdateRuneday")]
        public double LastUpdated { get; set; }
    }
}
