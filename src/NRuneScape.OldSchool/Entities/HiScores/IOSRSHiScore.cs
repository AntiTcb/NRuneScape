namespace NRuneScape.OldSchool
{
    public interface IOSRSHiScore : IHiscore
    {
        OSGameMode GameMode { get; }
    }
}