using System;
using System.Linq;
using System.Collections.Concurrent;
using NRuneScape.API;

namespace NRuneScape.RuneScape3.API
{
    internal sealed class RS3HiscoreData
    {
        public ConcurrentDictionary<Activity, ActivityHiscore> Activities { get; set; }
        public ConcurrentDictionary<Skill, SkillHiscore> Skills { get; set; }

        public RS3HiscoreData(IHiscoreModel[] hiscores)
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
                var entity = SkillHiscore.Create(hiscores[index] as SkillHiscoreModel, skill);
                skills.AddOrUpdate(skill, entity, (x, y) => entity);
            }

            void AddActivity(Activity activity)
            {
                int index = EnumUtils.GetInfo(activity).Index;
                var entity = ActivityHiscore.Create(hiscores[index] as ActivityHiscoreModel, activity);
                activities.AddOrUpdate(activity, entity, (x, y) => entity);
            }
        }

        public static RS3HiscoreData Parse(string data)
        {
            var splitData = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var hiScores = splitData.Select(d => SkillHiscoreModel.TryParseData(d, out var skill) ? skill as IHiscoreModel : ActivityHiscoreModel.ParseData(d)).ToArray();

            return new RS3HiscoreData(hiScores);
        }
    }
}
