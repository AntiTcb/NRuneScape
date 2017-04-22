using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NRuneScape.OldSchool.API
{
    internal sealed class OSRSHiScoreData
    {
        public ConcurrentDictionary<OSRSActivity, OSRSActivityHiScore> Activities { get; set; }
        public OSRSGameMode GameMode { get; set; }
        public ConcurrentDictionary<OSRSSkill, OSRSSkillHiScore> Skills { get; set; }

        public OSRSHiScoreData(IEnumerable<(int Index, IHiScore Score)> hiScores, OSRSGameMode source)
        {
            var skills = new ConcurrentDictionary<OSRSSkill, OSRSSkillHiScore>();
            var activities = new ConcurrentDictionary<OSRSActivity, OSRSActivityHiScore>();
            foreach (var hiScore in hiScores)
            {   
                if (hiScore.Index < 24)
                {
                    var skillName = hiScore.Index.GetSkillByIndex();
                    var skillEntity = OSRSSkillHiScore.Create(hiScore.Score as SkillHiScore, skillName, source);
                    skills.AddOrUpdate(skillName, skillEntity, (x, y) => skillEntity);
                    continue;
                }
                var activityName = hiScore.Index.GetActivityByIndex();
                var activityEntity = OSRSActivityHiScore.Create(hiScore.Score as ActivityHiScore, activityName, source);
                activities.AddOrUpdate(activityName, activityEntity, (x, y) => activityEntity);
            }
            Skills = skills;
            Activities = activities;
        }
    }
}