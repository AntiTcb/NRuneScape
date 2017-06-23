namespace NRuneScape
{
    public interface ITradeHistory
    {
        PriceTrend Trend { get; }
        string Price { get; }
        string Change { get; }
    }
}
