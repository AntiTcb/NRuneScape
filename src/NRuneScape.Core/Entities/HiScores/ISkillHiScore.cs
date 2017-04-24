namespace NRuneScape
{
    public interface ISkillHiscore : IHiscore
    {
        long? Experience { get; }                                                 
        int? Level { get; }
    }
}