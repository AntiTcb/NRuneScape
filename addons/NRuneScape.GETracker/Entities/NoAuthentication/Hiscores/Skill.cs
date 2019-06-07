using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct Skill
    {
        [ModelProperty("rank")]
        public int? Rank { get; set; }
        [ModelProperty("level")]
        public int? Level { get; set; }
        [ModelProperty("exp")]
        public long? Experience { get; set; }
    }
}
