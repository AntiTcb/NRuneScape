namespace NRuneScape
{
    public interface IActivityHiScore : IHiScore
    {
        /// <summary> Gets the score for this high score value. </summary>
        int Score { get; }
    }
}