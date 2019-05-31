using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class CleanHerbData
    {
        [ModelProperty("profit")]
        public int Profit { get; set; }
        [ModelProperty("material")]
        public Item Material { get; set; }
        [ModelProperty("target")]
        public Item Target { get; set; }
    }

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

    public class UnfinishedPotionData
    {
        [ModelProperty("herb")]
        public Item Herb { get; set; }
        [ModelProperty("unf")]
        public Item UnfinishedPotion { get; set; }
        [ModelProperty("profit")]
        public int Profit { get; set; }
    }

    public class DecantPotionData
    {
        [ModelProperty("cheapest")]
        public Dictionary<string, int> CheapestDose { get; set; }
        [ModelProperty("profit")]
        public int Profit { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
        [ModelProperty("dose")]
        public Dictionary<int, Item> Doses { get; set; }
    }
}
