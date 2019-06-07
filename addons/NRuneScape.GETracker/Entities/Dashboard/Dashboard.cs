using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Dashboard
    {
        [ModelProperty("tile")]
        public TransactionSummary Tiles { get; set; }
        [ModelProperty("favouriteItems")]
        public Item[] FavouriteItems { get; set; }
        [ModelProperty("suggestedItems")]
        public Item[] SuggestedItems { get; set; }
    }
}
