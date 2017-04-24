namespace NRuneScape.OldSchool
{
    public interface IOSRSHiScore
    {
        /// <summary>
        /// Gets the game mode of the account for this hiscore
        /// </summary>
        OSGameMode GameMode { get; }
    }
}