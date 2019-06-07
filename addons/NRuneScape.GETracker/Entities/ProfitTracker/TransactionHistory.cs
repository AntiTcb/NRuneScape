using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionHistory
    {
        [ModelProperty("avgTransactionTime")]
        public string AverageTransactionTime { get; set; }
        [ModelProperty("avgProfit")]
        public int AverageProfit { get; set; }
        [ModelProperty("avgRoi")]
        public float AverageROI { get; set; }
        [ModelProperty("totalProfit")]
        public int TotalProfit { get; set; }
        [ModelProperty("totalTransactions")]
        public int TotalTransactions { get; set; }
        [ModelProperty("totalQty")]
        public int TotalQty { get; set; }
        [ModelProperty("gpPerHr")]
        public int GoldPerHour { get; set; }
    }
}
