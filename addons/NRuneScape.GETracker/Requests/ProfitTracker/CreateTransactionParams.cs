using System;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class CreateTransactionParams
    {
        [ModelProperty("status")]
        public TransactionStatus Status { get; set; }

        [ModelProperty("item_id")]
        public int ItemId { get; set; }
        [ModelProperty("qty")]
        public int Quantity { get; set; }
        [ModelProperty("buy_price")]
        public int BuyPrice { get; set; }
        [ModelProperty("buy_date")]
        public Optional<DateTimeOffset> BuyDate { get; set; }
        [ModelProperty("intended_sell_price")]
        public Optional<int> IntendedSellPrice { get; set; }
        [ModelProperty("change_pivot")]
        public Optional<int> ChangePivot { get; set; }
        [ModelProperty("threshold")]
        public Optional<int> Threshhold { get; set; }

        [ModelProperty("sell_price")]
        public Optional<int> SellPrice { get; set; }
        [ModelProperty("bought_date")]
        public Optional<DateTimeOffset> BoughtDate { get; set; }
        [ModelProperty("sell_date")]
        public Optional<DateTimeOffset> SellDate { get; set; }
        [ModelProperty("sold_date")]
        public Optional<DateTimeOffset> SoldDate { get; set; }
    }
}
