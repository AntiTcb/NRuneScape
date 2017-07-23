using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace NRuneScape.API
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    internal sealed class ItemModel
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
        public TradeMetadataModel Current { get; set; }
        [JsonProperty("today")]
        public TradeMetadataModel Today { get; set; }

        [JsonProperty("day30", NullValueHandling = NullValueHandling.Include)]
        internal TradeMetadataModel Day30 { get; set; }    
        [JsonProperty("day90")]
        internal TradeMetadataModel Day90 { get; set; }    
        [JsonProperty("day180")]
        internal TradeMetadataModel Day180 { get; set; } 

        public Dictionary<HistoryPeriod, TradeMetadataModel> TradeHistories
            => new Dictionary<HistoryPeriod, TradeMetadataModel>
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
