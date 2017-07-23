namespace NRuneScape.OldSchool
{
    public interface IOSHiscoreCharacter : IHiscoreCharacter
    {
        ActivityHiscore BountyHunter { get; }
        ActivityHiscore BountyHunterRogue { get; }
        ActivityHiscore ClueScrollsAll { get; }
        ActivityHiscore ClueScrollsEasy { get; }
        ActivityHiscore ClueScrollsMedium { get; }
        ActivityHiscore ClueScrollsHard { get; }
        ActivityHiscore ClueScrollsElite { get; }
        ActivityHiscore ClueScrollsMaster { get; }
    }
}
