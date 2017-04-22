namespace NRuneScape
{
    public interface ISkillHiScore : IHiScore
    {
        /// <summary> Gets the experience for this high score value. </summary>
        long Experience { get; }

        /// <summary> Gets the level for this high score value. </summary>
        int Level { get; }
    }
}