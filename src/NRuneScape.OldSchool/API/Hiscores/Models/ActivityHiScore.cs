using System;

namespace NRuneScape.OldSchool.API
{
    internal sealed class ActivityHiscore : IHiscoreModel
    {
        public int Rank { get; set; }
        public int Score { get; set; }

        public static ActivityHiscore ParseData(string data)
        {
            var splitData = data.Split(',');
            if (splitData.Length != 2) throw new ArgumentException($"{nameof(data)} contained too few data points.");

            return new ActivityHiscore
            {
                Rank = int.Parse(splitData[0]),
                Score = int.Parse(splitData[1])
            };
        }

        public static bool TryParse(string data, out ActivityHiscore hiScore)
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