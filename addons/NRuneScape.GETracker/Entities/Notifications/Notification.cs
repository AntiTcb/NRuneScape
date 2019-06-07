using System;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Notification
    {
        [ModelProperty("notificationId")]
        public string NotificationId { get; set; }
        [ModelProperty("subject")]
        public string Subject { get; set; }
        [ModelProperty("replied")]
        public bool HasReplied { get; set; }
        [ModelProperty("read")]
        public bool HasBeenRead { get; set; }
        [ModelProperty("deleted")]
        public bool IsDeleted { get; set; }
        [ModelProperty("favourite")]
        public bool IsFavourite { get; set; }
        [ModelProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        [ModelProperty("fromUser")]
        public User User { get; set; }
        [ModelProperty("plainText")]
        public Optional<string> PlainText { get; set; }
    }
}
