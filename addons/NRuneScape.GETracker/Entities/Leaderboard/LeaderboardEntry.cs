using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class LeaderboardEntry
    {
        [ModelProperty("name")]
        public string Username { get; set; }
        [ModelProperty("totalProfit")]
        public int TotalProfit { get; set; }
        [ModelProperty("periodProfit")]
        public int PeriodProfit { get; set; }
        [ModelProperty("position")]
        public int Position { get; set; }
        [ModelProperty("slug")]
        public string Slug { get; set; }
        [ModelProperty("premium")]
        public bool IsPremium { get; set; }
        [ModelProperty("trial")]
        public bool IsTrial { get; set; }
        [ModelProperty("staff")]
        public bool IsStaff { get; set; }
        [ModelProperty("profilePic")]
        public string ProfilePictureUrl { get; set; }
        [ModelProperty("url")]
        public string Url { get; set; }
    }
}
