using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class PriceAlertMethods
    {
        [ModelProperty("email")]
        public bool ByEmail { get; set; }
        [ModelProperty("sms")]
        public bool BySms { get; set; }
    }
}
