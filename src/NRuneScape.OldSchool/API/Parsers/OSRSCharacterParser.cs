using System;
using System.Linq;

namespace NRuneScape.OldSchool.API
{
    internal static class OSRSCharacterParser
    {
        public static OSRSHiScoreData ParseHiScoreData(string data, OSGameMode source)
        {
            var splitData = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var hiScores = splitData.Select((x, i) => (i, SkillHiScore.TryParseSkillData(x, out var skill) ? skill as IHiScore : ActivityHiScore.ParseActivityData(x)));

            return new OSRSHiScoreData(hiScores, source);
        }
    }
}