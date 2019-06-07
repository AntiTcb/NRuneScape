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
}
