using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct PremiumFlags
    {
        [ModelProperty("premium")]
        public bool IsPremium { get; set; }
        [ModelProperty("trial")]
        public bool IsTrial { get; set; }
        [ModelProperty("view")]
        public bool IsView { get; set; }
    }
}
