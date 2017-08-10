using System;
using Newtonsoft.Json;

namespace NRuneScape.RuneScape3.API
{
    internal class SeasonalDetailsModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public object Id { get; set; }
        [JsonProperty("recurrence")]
        public int Recurrence { get; set; }
        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("daysRunning")]
        public int DaysRunning { get; set; }
        [JsonProperty("monthsRunning")]
        public int MonthsRunning { get; set; }
    }
}
