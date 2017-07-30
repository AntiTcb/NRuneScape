using System.Collections.Concurrent;
using NRuneScape.API;

namespace NRuneScape.OldSchool.API
{
    internal sealed class HiscoreCharacter : IHiscoreCharacterModel
    {
        public ConcurrentDictionary<Activity, ActivityHiscore> Activities { get; set; }
        public string Name { get; set; }
        public ConcurrentDictionary<Skill, SkillHiscore> Skills { get; set; }
        public GameMode GameMode { get; set; }

        public HiscoreCharacter(string name, GameMode gameMode, OSHiscoreData data)
        {
            Name = name;
            GameMode = gameMode;
            Skills = data.Skills;
            Activities = data.Activities;
        }
    }
}