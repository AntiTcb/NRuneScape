using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Leaderboard
    {
        [ModelProperty("name")]
        public string Name { get; set; }
        [ModelProperty("slug")]
        public string Slug { get; set; }
        [ModelProperty("url")]
        public string Url { get; set; }
    }
}
