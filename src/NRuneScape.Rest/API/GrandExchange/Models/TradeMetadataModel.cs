using System.Diagnostics;
using Newtonsoft.Json;

namespace NRuneScape.API
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    internal class TradeMetadataModel
    {
        [JsonProperty("trend")]
        public PriceTrend Trend { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("change")]
        public string Change { set; get; }

        private string DebuggerDisplay => $"{Trend}: P:{Price} C:{Change}";
    }
}
