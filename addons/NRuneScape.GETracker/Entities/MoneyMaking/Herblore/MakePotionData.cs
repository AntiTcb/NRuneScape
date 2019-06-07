using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class MakePotionData
    {
        [ModelProperty("ingredients")]
        public Dictionary<string, int> Ingredients { get; set; }
        [ModelProperty("doses")]
        public int Doses { get; set; }
        [ModelProperty("level")]
        public int Level { get; set; }
        [ModelProperty("profitCost")]
        public int ProfitCost { get; set; }
        [ModelProperty("profit")]
        public int Profit { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
        [ModelProperty("primary")]
        public Item PrimaryItem { get; set; }
        [ModelProperty("secondary")]
        public Item SecondaryItem { get; set; }
    }
}
