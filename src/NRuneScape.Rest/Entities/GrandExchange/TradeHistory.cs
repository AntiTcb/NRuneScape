using System.Diagnostics;
using Model = NRuneScape.API.TradeMetaData;

namespace NRuneScape.Rest
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public class TradeHistory : ITradeHistory
    {
        public PriceTrend Trend { get; internal set; }
        public string Price { get; internal set; }
        public string Change { get; internal set; }

        internal static TradeHistory Create(Model model)
        {
            return new TradeHistory
            {
                Trend = model?.Trend ?? PriceTrend.Neutral,
                Price = model?.Price,
                Change = model?.Change
            };
        }

        public override string ToString() => DebuggerDisplay;
        private string DebuggerDisplay => $"{Trend}: P:{Price} C:{Change}";
    }
}