using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public enum TransactionStatus
    {
        [ModelEnumValue("bought")]
        Bought,
        [ModelEnumValue("selling")]
        Selling,
        [ModelEnumValue("sold")]
        Sold
    }
}
