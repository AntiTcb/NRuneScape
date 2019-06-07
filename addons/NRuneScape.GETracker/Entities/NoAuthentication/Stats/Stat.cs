using System;
using System.Collections.Generic;
using System.Text;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Stat
    {
        // TODO: Ulong?
        [ModelProperty("totalProfit")]
        public long TotalProfit { get; set; }
        [ModelProperty("avgProfit")]
        public int AverageProfit { get; set; }
        [ModelProperty("totalTransactions")]
        public int TransactionCount { get; set; }
        [ModelProperty("totalItems")]
        public int ItemCount { get; set; }
        [ModelProperty("usersActive")]
        public int ActiveUserCount { get; set; }
        [ModelProperty("usersOnline")]
        public int OnlineUserCount { get; set; }
        [ModelProperty("users")]
        public Dictionary<string, int> Users { get; set; }
        [ModelProperty("popularItems")]
        public PopularItem[] PopularItems { get; set; }
    }
}
