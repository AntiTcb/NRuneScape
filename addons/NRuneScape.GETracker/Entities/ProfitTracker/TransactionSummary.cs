using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionSummary
    {
        [ModelProperty("mostProfit")]
        public TransactionProfitSummary MostProfit { get; set; }
        [ModelProperty("mostSold")]
        public TransactionProfitSummary MostSold { get; set; }
        [ModelProperty("mostFrequent")]
        public TransactionProfitSummary MostFrequent { get; set; }
        [ModelProperty("activeTransactions")]
        public int ActiveTransactions { get; set; }
        [ModelProperty("total")]
        public Dictionary<string, int> Total { get; set; }
    }
}
