using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class MagicTabletData
    {
        [ModelProperty("target")]
        public Target<Dictionary<string, string[]>> Target { get; set; }
        [ModelProperty("cost")]
        public CostData Cost { get; set; }
    }
}
