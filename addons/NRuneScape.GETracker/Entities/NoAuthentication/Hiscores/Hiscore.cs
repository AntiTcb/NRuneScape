using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Hiscore
    {
        [ModelProperty("rsn")]
        public string Username { get; set; }
        [ModelProperty("stats")]
        public Dictionary<string, Skill> Stats { get; set; }
        [ModelProperty("bountyHunter")]
        public Dictionary<string, Activity> BountyHunter { get; set; }
        [ModelProperty("clueScroll")]
        public Dictionary<string, Activity> ClueScroll { get; set; }
    }
}
