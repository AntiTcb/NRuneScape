using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class BlastFurnaceData
    {
        [ModelProperty("target")]
        public Target<object> Target { get; set; }
        [ModelProperty("cost")]
        public CostData Cost { get; set; }
    }
}
