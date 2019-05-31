using System;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class UpdateTransactionParams
    {
        [ModelProperty("status")]
        public TransactionStatus Status { get; set; }

        // Bought
        [ModelProperty("bought_date")]
        public Optional<DateTimeOffset> BoughtDate { get; set; }

        // Selling
        [ModelProperty("sell_price")]
        public Optional<int> SellPrice { get; set; }
        [ModelProperty("sell_date")]
        public Optional<DateTimeOffset> SellDate { get; set; }
        [ModelProperty("qty")]
        public Optional<int> Quantity { get; set; }
        [ModelProperty("mark_as_sold")]
        public Optional<bool> MarkAsSold { get; set; }

        // Sold
        [ModelProperty("sold_date")]
        public Optional<DateTimeOffset> SoldDate { get; set; }
    }
}
