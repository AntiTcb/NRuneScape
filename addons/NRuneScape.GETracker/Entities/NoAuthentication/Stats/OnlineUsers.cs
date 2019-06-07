using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class OnlineUsers
    {
        [ModelProperty("onlineCount")]
        public Dictionary<string, int> UserCounts { get; set; }
        [ModelProperty("users")]
        public Dictionary<string, User[]> Users { get; set; }
    }
}
