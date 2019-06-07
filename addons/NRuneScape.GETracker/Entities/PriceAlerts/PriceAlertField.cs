using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public enum PriceAlertField
    {
        [ModelEnumValue("current")]
        Current,
        [ModelEnumValue("selling")]
        Selling,
        [ModelEnumValue("buying")]
        Buying,
        [ModelEnumValue("profit")]
        Profit
    }
}
