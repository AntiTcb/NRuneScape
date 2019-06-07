using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct Activity
    {
        [ModelProperty("rank")]
        public int? Rank { get; set; }
        [ModelProperty("score")]
        public int? Score { get; set; }
    }
}
