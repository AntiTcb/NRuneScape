using System;
using System.Collections.Concurrent;
using System.Linq;
using NRuneScape.API;

namespace NRuneScape.OldSchool.API
{
    internal sealed class OSHiscoreData
    {
        public ConcurrentDictionary<Activity, ActivityHiscore> Activities { get; set; }
        public ConcurrentDictionary<Skill, SkillHiscore> Skills { get; set; }

        public OSHiscoreData(IHiscoreModel[] hiScores)
        {
            var skills = new ConcurrentDictionary<Skill, SkillHiscore>();
            var activities = new ConcurrentDictionary<Activity, ActivityHiscore>();
            var skillValues = Enum.GetValues(typeof(Skill)).Cast<Skill>();
            var activityValues = Enum.GetValues(typeof(Activity)).Cast<Activity>();

            foreach (var skill in skillValues)
                AddSkill(skill);

            foreach (var activity in activityValues)
                AddActivity(activity);

            Skills = skills;
            Activities = activities;

            void AddSkill(Skill skill)
            {
                int index = EnumUtils.GetInfo(skill).Index;
                var skillEntity = SkillHiscore.Create(hiScores[index] as SkillHiscoreModel, skill);
                skills.AddOrUpdate(skill, skillEntity, (x, y) => skillEntity);
            }

            void AddActivity(Activity activity)
            {
                int index = EnumUtils.GetInfo(activity).Index;
                var activityEntity = ActivityHiscore.Create(hiScores[index] as ActivityHiscoreModel, activity);
                activities.AddOrUpdate(activity, activityEntity, (x, y) => activityEntity);
            }
        }

        public static OSHiscoreData Parse(string data)
        {
            var splitData = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var hiScores = splitData.Select(d => SkillHiscoreModel.TryParseData(d, out var skill) ? skill as IHiscoreModel : ActivityHiscoreModel.ParseData(d)).ToArray();

            return new OSHiscoreData(hiScores);
        }
    }
}