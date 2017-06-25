using System;
using System.Linq;

namespace NRuneScape.OldSchool.API
{
    internal static class OSHiscoreParser
    {
        public static OSHiscoreData ParseHiScoreData(string data)
        {
            var splitData = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var hiScores = splitData.Select(d => SkillHiScore.TryParseData(d, out var skill) ? skill as IHiscoreModel : ActivityHiscore.ParseData(d)).ToArray();

            return new OSHiscoreData(hiScores);
        }
    }
}