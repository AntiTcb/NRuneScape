namespace NRuneScape
{
    public interface ISkillHiscore : IHiscore
    {
        /// <summary>
        /// Gets the experience of this skill hiscore value. Returns null if unranked.
        /// </summary>
        long? Experience { get; }                            
        /// <summary>
        /// Gets the level of this skill hiscore value. Returns null if unranked.
        /// </summary>
        int? Level { get; }
    }
}