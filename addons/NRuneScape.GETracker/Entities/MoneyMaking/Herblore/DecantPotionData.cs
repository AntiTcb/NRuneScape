using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{

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
