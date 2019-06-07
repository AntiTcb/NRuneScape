using System;
using System.Collections.Generic;
using System.Text;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Update
    {
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("title")]
        public string Title { get; set; }
        [ModelProperty("description")]
        public string Description { get; set; }
        // TODO: enum
        [ModelProperty("category")]
        public string Category { get; set; }
        [ModelProperty("link")]
        public string Url { get; set; }
        [ModelProperty("createdAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [ModelProperty("summary")]
        public Optional<UpdateSummary> Summary { get; set; }
        [ModelProperty("markdown")]
        public Optional<string> Markdown { get; set; }
    }
}
