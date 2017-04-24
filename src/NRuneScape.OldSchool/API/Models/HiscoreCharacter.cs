using System.Collections.Concurrent;

namespace NRuneScape.OldSchool.API
{
    internal sealed class HiscoreCharacter
    {
        public ConcurrentDictionary<OSActivity, OSActivityHiscore> Activities { get; set; }
        public string Name { get; set; }
        public ConcurrentDictionary<OSSkill, OSSkillHiscore> Skills { get; set; }
        public OSGameMode Source { get; set; }

        public HiscoreCharacter(string name, OSGameMode source, OSRSHiScoreData data)
        {
            Name = name;
            Source = source;
            Skills = data.Skills;
            Activities = data.Activities;
        }
    }
}