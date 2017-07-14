using System.Diagnostics;
using Model = NRuneScape.OldSchool.API.SkillHiScore;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSSkillHiscore : ISkillHiscore
    {
        /// <summary> Gets the skill name for this hiscore. Returns null if unranked. </summary>
        public string Name { get; private set; }         

        /// <summary> Gets the experience for this skill hiscore. </summary>
        public long Experience { get; private set; }
        /// <summary> Gets the level for this skill hiscore. Returns null if unranked. </summary>
        public int Level { get; private set; }
        /// <summary> Gets the rank for this skill hiscore. Returns null if unranked. </summary>
        public int Rank { get; private set; }

        internal static OSSkillHiscore Create(Model model, Skill name) => new OSSkillHiscore
        {
            Name = name.ToString(),
            Rank = model.Rank,
            Level = model.Level,
            Experience = model.Experience
        };

        public void Deconstruct(out string name,  out int? level, out int? rank, out long? experience)
        {
            name = Name;                         
            level = Level;
            rank = Rank;
            experience = Experience;
        }                                        

        //IHiscore
        int? IHiscore.Rank => Rank;

        private string DebuggerDisplay => $"({Name}) L:{Level} | R:{Rank:N0} | E:{Experience:N0}";
    }
}