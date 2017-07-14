using System;
using System.Collections.Concurrent;

namespace NRuneScape.OldSchool.API
{
    internal sealed class OSHiscoreData
    {
        public ConcurrentDictionary<Activity, OSActivityHiscore> Activities { get; set; }
        public ConcurrentDictionary<Skill, OSSkillHiscore> Skills { get; set; }

        public OSHiscoreData(IHiscoreModel[] hiScores)
        {
            var skills = new ConcurrentDictionary<Skill, OSSkillHiscore>();
            var activities = new ConcurrentDictionary<Activity, OSActivityHiscore>();
            var skillValues = Enum.GetValues(typeof(Skill));
            var activityValues = Enum.GetValues(typeof(Activity));

            foreach (object skill in skillValues)
                AddSkill((Skill)skill);

            foreach (object activity in activityValues)
                AddActivity((Activity)activity);

            Skills = skills;
            Activities = activities;


            void AddSkill(Skill skill)
            {
                int index = EnumUtils.GetInfo(skill).Index;
                var skillEntity = OSSkillHiscore.Create(hiScores[index] as SkillHiScore, skill);
                skills.AddOrUpdate(skill, skillEntity, (x, y) => skillEntity);
            }

            void AddActivity(Activity activity)
            {
                int index = EnumUtils.GetInfo(activity).Index;
                var activityEntity = OSActivityHiscore.Create(hiScores[index] as ActivityHiscore, activity);
                activities.AddOrUpdate(activity, activityEntity, (x, y) => activityEntity);
            }
        }
    }
}