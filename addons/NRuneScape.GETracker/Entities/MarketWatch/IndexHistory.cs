using System;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class IndexHistory
    {
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("osrs_index_id")]
        public int OldSchoolIndexId { get; set; }
        [ModelProperty("index")]
        public float Index { get; set; }
        [ModelProperty("index_date")]
        public DateTimeOffset IndexDate { get; set; }
        [ModelProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [ModelProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
