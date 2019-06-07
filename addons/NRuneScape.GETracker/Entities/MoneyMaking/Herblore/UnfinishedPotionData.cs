using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class UnfinishedPotionData
    {
        [ModelProperty("herb")]
        public Item Herb { get; set; }
        [ModelProperty("unf")]
        public Item UnfinishedPotion { get; set; }
        [ModelProperty("profit")]
        public int Profit { get; set; }
    }
}
