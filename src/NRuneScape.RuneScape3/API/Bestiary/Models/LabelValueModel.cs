using Newtonsoft.Json;

namespace NRuneScape.RuneScape3.API
{
    internal class LabelValueModel
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
