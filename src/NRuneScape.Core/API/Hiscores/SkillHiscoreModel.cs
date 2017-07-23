using System;
using System.Diagnostics;

namespace NRuneScape.API
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class SkillHiscoreModel : IHiscoreModel
    {
        public long Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }

        public static SkillHiscoreModel ParseData(string data)
        {
            var splitData = data.Split(',');
            if (splitData.Length != 3) throw new ArgumentException($"{nameof(data)} contained too few data points.");

            return new SkillHiscoreModel
            {
                Rank = int.Parse(splitData[0]),
                Level = int.Parse(splitData[1]),
                Experience = long.Parse(splitData[2])
            };
        }

        public static bool TryParseData(string data, out SkillHiscoreModel hiScore)
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

        private string DebuggerDisplay => $"L:{Level} | R:{Rank:N0} | E:{Experience:N0}";
    }
}