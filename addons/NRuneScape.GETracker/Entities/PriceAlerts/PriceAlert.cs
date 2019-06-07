using System;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class PriceAlert
    {
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("methods")]
        public PriceAlertMethods Methods { get; set; }
        [ModelProperty("alert")]
        public PriceAlertDetails AlertDetails { get; set; }
        // TODO: Bool?
        [ModelProperty("notified")]
        public int Notified { get; set; }
        [ModelProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
    }
}
