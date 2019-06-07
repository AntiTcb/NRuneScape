using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class PriceAlertDetails
    {
        [ModelProperty("type")]
        public PriceAlertType Type { get; set; }
        [ModelProperty("field")]
        public PriceAlertField Field { get; set; }
        [ModelProperty("pivot")]
        public int Pivot { get; set; }
    }
}
