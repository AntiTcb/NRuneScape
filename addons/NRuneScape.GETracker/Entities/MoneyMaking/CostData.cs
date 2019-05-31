using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class CostData
    {
        [ModelProperty("xp")]
        public int Experience { get; set; }
        [ModelProperty("cost")]
        public int Cost { get; set; }
        [ModelProperty("profitHr")]
        public int ProfitPerHour { get; set; }

        [ModelProperty("baseCost")]
        public Optional<int> BaseCost { get; set; }

        [ModelProperty("profit")]
        public Optional<int> Profit { get; set; }
    }
}
