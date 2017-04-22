using System.Diagnostics;
using Model = NRuneScape.OldSchool.API.SkillHiScore;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSRSSkillHiScore : ISkillHiScore, IOSRSHiScore
    {
        public long Experience { get; private set; }
        public OSRSGameMode GameMode { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }

        internal static OSRSSkillHiScore Create(Model model, OSRSSkill name, OSRSGameMode gameMode)
        {
            return new OSRSSkillHiScore
            {
                Name = name.ToString(),
                GameMode = gameMode,
                Rank = model.Rank,
                Level = model.Level,
                Experience = model.Experience
            };
        }

        private string DebuggerDisplay => $"({Name} | {GameMode}) L:{Level} | R:{Rank:N0} | E:{Experience:N0}";
    }
}