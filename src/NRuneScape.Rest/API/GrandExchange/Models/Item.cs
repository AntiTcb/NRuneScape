using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace NRuneScape.API
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    internal sealed class Item
    {
        [JsonProperty("icon")]
        public Uri Icon { get; set; } 
        [JsonProperty("icon_large")]
        public Uri LargeIcon { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }       
        [JsonProperty("type")]
        public string Category { get; set; }
        [JsonProperty("typeIcon")]
        public Uri CategoryIcon { get; set; } 
        [JsonProperty("name")]
        public string Name { get; set; }      
        [JsonProperty("description")]
        public string Description { get; set; }       
        [JsonProperty("members")]
        public bool IsMembersItem { get; set; }
        [JsonProperty("current")]
        public TradeMetaData Current { get; set; }
        [JsonProperty("today")]
        public TradeMetaData Today { get; set; }

        [JsonProperty("day30", NullValueHandling = NullValueHandling.Include)]
        internal TradeMetaData Day30 { get; set; }    
        [JsonProperty("day90")]
        internal TradeMetaData Day90 { get; set; }    
        [JsonProperty("day180")]
        internal TradeMetaData Day180 { get; set; } 

        public Dictionary<HistoryPeriod, TradeMetaData> TradeHistories
            => new Dictionary<HistoryPeriod, TradeMetaData>
                {
                    { HistoryPeriod.Days30, Day30 },
                    { HistoryPeriod.Days90, Day90 },
                    { HistoryPeriod.Days180, Day180 },
                    { HistoryPeriod.Current, Current },
                    { HistoryPeriod.Today, Today }
                };

        private string DebuggerDisplay => $"{Name} | {Id}";
    }


}
