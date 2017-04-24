namespace NRuneScape.OldSchool
{
    public interface IOSHiscoreCharacter : IHiscoreCharacter
    {
        OSActivityHiscore BountyHunterHunter { get; }
        OSActivityHiscore BountyHunterRogue { get; }
        OSActivityHiscore ClueScrollsAll { get; }
        OSActivityHiscore ClueScrollsEasy { get; }
        OSActivityHiscore ClueScrollsMedium { get; }
        OSActivityHiscore ClueScrollsHard { get; }
        OSActivityHiscore ClueScrollsElite { get; }
        OSActivityHiscore ClueScrollsMaster { get; }
    }
}
