using System.Diagnostics;
using Model = NRuneScape.API.SkillHiscoreModel;

namespace NRuneScape.RuneScape3
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SkillHiscore : ISkillHiscore
    {  
        /// <summary> Gets the skill name for this hiscore. Returns null if unranked. </summary>
        public string Name { get; private set; }

        /// <summary> Gets the experience for this skill hiscore. </summary>
        public long? Experience 
        {
            get => _exp != -1 ? _exp : default(long?);
            private set => _exp = value ?? -1;
        }
        /// <summary> Gets the level for this skill hiscore. Returns null if unranked. </summary>
        public int? Level 
        {
            get => _level != -1 ? _level : default(int?);
            private set => _level = value ?? -1;
        }
        /// <summary> Gets the rank for this skill hiscore. Returns null if unranked. </summary>
        public int? Rank 
        {
            get => _rank != -1 ? _rank : default(int?);
            private set => _rank = value ?? -1;
        }

        internal static SkillHiscore Create(Model model, Skill skill) => new SkillHiscore
        {
            Name = skill.ToString(),
            Rank = model.Rank,
            Level = model.Level,
            Experience = model.Experience
        };

        public void Deconstruct(out string name, out int? level, out int? rank, out long? experience)
        {
            name = Name;
            level = Level;
            rank = Rank;
            experience = Experience;
        }

        public override string ToString() => $"{Name} / {Level?.ToString() ?? "Unranked"} | {Rank?.ToString("N0") ?? "Unranked"} | {Experience?.ToString("N0") ?? "Unranked"}";
        private string DebuggerDisplay => $"({Name}) L:{Level?.ToString() ?? "Unranked"} | R:{Rank?.ToString("N0") ?? "Unranked"} | E:{Experience?.ToString("N0") ?? "Unranked"}";
        private int _rank;
        private int _level;
        private long _exp;
    }
}
