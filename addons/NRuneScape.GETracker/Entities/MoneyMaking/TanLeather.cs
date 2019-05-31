using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TanLeatherData
    {
        [ModelProperty("leather")]
        public Item Leather { get; set; }
        [ModelProperty("tanned")]
        public Item Tanned { get; set; }
        [ModelProperty("cost")]
        public CostData Cost { get; set; }
    }
}
