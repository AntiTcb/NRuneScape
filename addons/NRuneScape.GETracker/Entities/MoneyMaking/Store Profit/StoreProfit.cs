using System;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Store
    {
        [ModelProperty("storeId")]
        public int StoreId { get; set; }
        [ModelProperty("name")]
        public string Name { get; set; }
        [ModelProperty("description")]
        public string Description { get; set; }
        [ModelProperty("wikiLink")]
        public string WikiUrl { get; set; }
        [ModelProperty("members")]
        public bool IsMembers { get; set; }
        [ModelProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
