using System;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Index
    {
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("name")]
        public string Name { get; set; }
        [ModelProperty("updated")]
        public DateTimeOffset Updated { get; set; }
        [ModelProperty("currentIndex")]
        public float CurrentIndex { get; set; }
        [ModelProperty("indexChange")]
        public float IndexCHange { get; set; }
        [ModelProperty("totalItems")]
        public int TotalItems { get; set; }

        [ModelProperty("history")]
        public Optional<IndexHistory[]> History { get; set; }
    }
}
