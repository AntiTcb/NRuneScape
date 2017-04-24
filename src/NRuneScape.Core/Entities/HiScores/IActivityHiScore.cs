namespace NRuneScape
{
    public interface IActivityHiscore : IHiscore
    {
        /// <summary> Gets the score for this hiscore. </summary>
        int Score { get; } 
    }
}