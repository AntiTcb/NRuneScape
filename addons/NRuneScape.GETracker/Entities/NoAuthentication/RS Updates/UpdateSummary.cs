using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct UpdateSummary
    {
        [ModelProperty("reduced")]
        public string Reduced { get; set; }
        [ModelProperty("content")]
        public string Content { get; set; }
    }
}