using System.Diagnostics;
using Model = NRuneScape.OldSchool.API.SkillHiScore;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSSkillHiscore : ISkillHiscore, IOSRSHiScore
    {
        /// <summary> Gets the skill name for this hiscore. Returns null if unranked. </summary>
        public string Name { get; private set; }  
        /// <summary> Gets the game mode for this skill hiscore. </summary>
        public OSGameMode GameMode { get; private set; }

        /// <summary> Gets the experience for this skill hiscore. </summary>
        public long Experience { get; private set; }
        /// <summary> Gets the level for this skill hiscore. Returns null if unranked. </summary>
        public int Level { get; private set; }
        /// <summary> Gets the rank for this skill hiscore. Returns null if unranked. </summary>
        public int Rank { get; private set; }

        internal static OSSkillHiscore Create(Model model, OSSkill name, OSGameMode gameMode)
        {
            return new OSSkillHiscore
            {
                Name = name.ToString(),
                GameMode = gameMode,
                Rank = model.Rank,
                Level = model.Level,
                Experience = model.Experience
            };
        }

        public void Deconstruct(out string name, out OSGameMode mode, out int? level, out int? rank, out long? experience)
        {
            name = Name;
            mode = GameMode;
            level = Level;
            rank = Rank;
            experience = Experience;
        }

        public void Deconstruct(out string name, out int? level, out int? rank, out long? experience)
        {
            name = Name;
            level = Level;
            rank = Rank;
            experience = Experience;
        }

        //IHiScore
        int? IHiscore.Rank => Rank;

        private string DebuggerDisplay => $"({Name} | {GameMode}) L:{Level} | R:{Rank:N0} | E:{Experience:N0}";
    }
}