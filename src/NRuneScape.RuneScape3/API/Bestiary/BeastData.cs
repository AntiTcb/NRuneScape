using System.Collections.Generic;
using Newtonsoft.Json;

namespace NRuneScape.RuneScape3.API
{
    internal class BeastData
    {
        [JsonProperty("level")]
        public double Level { get; set; }
        [JsonProperty("poisonous")]
        public bool Poisonous { get; set; }
        [JsonProperty("areas")]
        public string[] Areas { get; set; }
        [JsonProperty("defence")]
        public double Defence { get; set; }
        [JsonProperty("aggressive")]
        public bool Aggressive { get; set; }
        [JsonProperty("animations")]
        public Dictionary<string, int> Animations { get; set; }
        [JsonProperty("attack")]
        public double Attack { get; set; }
        [JsonProperty("attackable")]
        public bool Attackable { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public double Id { get; set; }
        [JsonProperty("members")]
        public bool Members { get; set; }
        [JsonProperty("lifepoints")]
        public double Lifepoints { get; set; }
        [JsonProperty("magic")]
        public double Magic { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("size")]
        public double Size { get; set; }
        [JsonProperty("ranged")]
        public double Ranged { get; set; }
        [JsonProperty("weakness")]
        public string Weakness { get; set; }
        [JsonProperty("xp")]
        public string Xp { get; set; }
    }
}
