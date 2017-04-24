using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NRuneScape.OldSchool.API
{
    internal sealed class OSRSHiScoreData
    {
        public ConcurrentDictionary<OSActivity, OSActivityHiscore> Activities { get; set; }
        public OSGameMode GameMode { get; set; }
        public ConcurrentDictionary<OSSkill, OSSkillHiscore> Skills { get; set; }

        public OSRSHiScoreData(IEnumerable<(int Index, IHiScore Score)> hiScores, OSGameMode source)
        {
            var skills = new ConcurrentDictionary<OSSkill, OSSkillHiscore>();
            var activities = new ConcurrentDictionary<OSActivity, OSActivityHiscore>();
            foreach (var hiScore in hiScores)
            {   
                if (hiScore.Index < 24)
                {
                    var skillName = hiScore.Index.ToOSRSSkill();
                    var skillEntity = OSSkillHiscore.Create(hiScore.Score as SkillHiScore, skillName, source);
                    skills.AddOrUpdate(skillName, skillEntity, (x, y) => skillEntity);
                    continue;
                }
                var activityName = hiScore.Index.ToOSRSActivity();
                var activityEntity = OSActivityHiscore.Create(hiScore.Score as ActivityHiScore, activityName, source);
                activities.AddOrUpdate(activityName, activityEntity, (x, y) => activityEntity);
            }
            Skills = skills;
            Activities = activities;
        }
    }
}