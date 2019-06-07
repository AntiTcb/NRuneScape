using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionProfitSummary
    {
        [ModelProperty("item")]
        public Item Item { get; set; }

        [ModelProperty("gp")]
        public Optional<int> Gold { get; set; }
        [ModelProperty("qty")]
        public Optional<int> Quantity { get; set; }
    }
}
