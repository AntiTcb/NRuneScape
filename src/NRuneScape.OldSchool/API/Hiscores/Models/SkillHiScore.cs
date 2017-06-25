using System;

namespace NRuneScape.OldSchool.API
{
    internal class SkillHiScore : IHiscoreModel
    {
        public long Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }

        public static SkillHiScore ParseData(string data)
        {
            var splitData = data.Split(',');
            if (splitData.Length != 3) throw new ArgumentException($"{nameof(data)} contained too few data points.");

            return new SkillHiScore
            {
                Rank = int.Parse(splitData[0]),
                Level = int.Parse(splitData[1]),
                Experience = long.Parse(splitData[2])
            };
        }

        public static bool TryParseData(string data, out SkillHiScore hiScore)
        {
            try
            {
                hiScore = ParseData(data);
                return true;
            }
            catch (ArgumentException)
            {
                hiScore = null;
                return false;
            }
        }
    }
}