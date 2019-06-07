using System.Collections.Generic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class PlankMakingData
    {
        [ModelProperty("target")]
        public Target<Dictionary<string, string[]>> Target { get; set; }
        [ModelProperty("cost")]
        public CostData Cost { get; set; }
    }
}
