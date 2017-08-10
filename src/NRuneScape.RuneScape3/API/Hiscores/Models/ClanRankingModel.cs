using Newtonsoft.Json;

namespace NRuneScape.RuneScape3.API
{
    internal class ClanRankingModel
    {     
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("clan_name")]
        public string Name { get; set; }
        [JsonProperty("clan_mates")]
        public int MemberCount { get; set; }
        [JsonProperty("xp_total")]
        public ulong Experience { get; set; }
    }
}
