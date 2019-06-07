using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Transaction
    {
        [ModelProperty("id")]
        public string Id { get; set; }
        [ModelProperty("status")]
        public TransactionStatus Status { get; set; }
        [ModelProperty("order")]
        public TransactionOrder Order { get; set; }
        [ModelProperty("dates")]
        public TransactionDates Dates { get; set; }
        [ModelProperty("merchLog")]
        public TransactionMerchLog MerchLog { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
    }
}
