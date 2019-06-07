using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct PopularItem
    {
        [ModelProperty("views")]
        public int Views { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
    }
}
