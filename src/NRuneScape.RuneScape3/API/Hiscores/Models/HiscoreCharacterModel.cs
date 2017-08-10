using System.Collections.Concurrent;   
using NRuneScape.API;

namespace NRuneScape.RuneScape3.API
{
    internal sealed class HiscoreCharacterModel : IHiscoreCharacterModel
    {
        public ConcurrentDictionary<Activity, ActivityHiscore> Activities { get; set; }
        public string Name { get; set; }
        public ConcurrentDictionary<Skill, SkillHiscore> Skills { get; set; }
        public GameMode GameMode { get; set; }

        public HiscoreCharacterModel(string name, GameMode gameMode, RS3HiscoreData data)
        {
            Name = name;
            GameMode = gameMode;
            Skills = data.Skills;
            Activities = data.Activities;
        }
    }
}
