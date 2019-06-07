using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class ItemProfit
    {
        [ModelProperty("transations")]
        public int Transactions { get; set; }
        [ModelProperty("totalTraded")]
        public int TotalTraded { get; set; }
        [ModelProperty("totalCost")]
        public int TotalCost { get; set; }
        [ModelProperty("totalRevenue")]
        public int TotalRevenue { get; set; }
        [ModelProperty("totalProfit")]
        public int TotalProfit { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
    }
}
