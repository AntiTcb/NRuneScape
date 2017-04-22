using System;

namespace NRuneScape.OldSchool.API
{
    internal sealed class ActivityHiScore : IHiScore
    {
        public int Rank { get; set; }
        public int Score { get; set; }

        public static ActivityHiScore ParseActivityData(string data)
        {
            var splitData = data.Split(',');
            if (splitData.Length != 2) throw new ArgumentException($"{nameof(data)} contained too few data points.");

            return new ActivityHiScore
            {
                Rank = int.Parse(splitData[0]),
                Score = int.Parse(splitData[1])
            };
        }

        public static bool TryParseActivityData(string data, out ActivityHiScore hiScore)
        {
            try
            {
                hiScore = ParseActivityData(data);
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