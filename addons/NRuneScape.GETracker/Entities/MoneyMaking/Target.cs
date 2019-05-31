using System.Collections.Generic;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Target<T>
    {
        [ModelProperty("materials")]
        public Optional<Dictionary<string, int>> Materials { get; set; }

        [ModelProperty("methods")]
        public T Methods { get; set; }

        [ModelProperty("baseCost")]
        public int BaseCost { get; set; }

        [ModelProperty("perHr")]
        public int PerHour { get; set; }

        [ModelProperty("item")]
        public Item Item { get; set; }
    }
}
