using System.Collections.Concurrent;

namespace NRuneScape.OldSchool.API
{
    internal sealed class Character
    {
        public ConcurrentDictionary<OSRSActivity, OSRSActivityHiScore> Activities { get; set; }
        public string Name { get; set; }
        public ConcurrentDictionary<OSRSSkill, OSRSSkillHiScore> Skills { get; set; }
        public OSRSGameMode Source { get; set; }

        public Character(string name, OSRSGameMode source, OSRSHiScoreData data)
        {
            Name = name;
            Source = source;
            Skills = data.Skills;
            Activities = data.Activities;
        }
    }
}