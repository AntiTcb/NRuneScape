using System;
using Newtonsoft.Json;

namespace NRuneScape.RuneScape3.API
{
    internal class SeasonalRankingModel
    {
        [JsonProperty("hiscoreId")]
        public ulong SeasonalId { get; set; }
        [JsonProperty("title")]
        public string SeasonalName { get; set; }
        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }
        [JsonProperty("score_raw")]
        public int ScoreRaw { get; set; }
        [JsonProperty("score_formatted")]
        public string ScoreFormatted { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
