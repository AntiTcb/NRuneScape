namespace NRuneScape
{
    public interface IHiScore
    {
        /// <summary> Gets the name for this high score value. </summary>
        string Name { get; }

        /// <summary> Gets the rank for this high score value. </summary>
        int Rank { get; }
    }
}