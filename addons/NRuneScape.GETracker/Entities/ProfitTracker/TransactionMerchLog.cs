using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class TransactionMerchLog
    {
        [ModelProperty("public")]
        public bool IsPublic { get; set; }
        [ModelProperty("verified")]
        public bool IsVerified { get; set; }
        [ModelProperty("rejected")]
        public bool? IsRejected { get; set; }
    }
}
