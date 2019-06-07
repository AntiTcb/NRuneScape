using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionOrder
    {
        [ModelProperty("itemId")]
        public int ItemId { get; set; }
        [ModelProperty("qty")]
        public int Quantity { get; set; }
        [ModelProperty("buyPrice")]
        public int BuyPrice { get; set; }
        [ModelProperty("sellPrice")]
        public int? SellPrice { get; set; }
        [ModelProperty("intendedSellPrice")]
        public int? IntendedSellPrice { get; set; }
    }
}
