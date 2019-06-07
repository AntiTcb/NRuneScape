using System;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionDates
    {
        [ModelProperty("buy")]
        public DateTimeOffset? Buy { get; set; }
        [ModelProperty("bought")]
        public DateTimeOffset? Bought { get; set; }
        [ModelProperty("sell")]
        public DateTimeOffset? Sell { get; set; }
        [ModelProperty("sold")]
        public DateTimeOffset? Sold { get; set; }
    }
}
