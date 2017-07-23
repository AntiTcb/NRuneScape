using System;
using System.Diagnostics;

namespace NRuneScape.API
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal sealed class ActivityHiscoreModel : IHiscoreModel
    {
        public int Rank { get; set; }
        public int Score { get; set; }

        public static ActivityHiscoreModel ParseData(string data)
        {
            var splitData = data.Split(',');
            if (splitData.Length != 2) throw new ArgumentException($"{nameof(data)} contained too few data points.");

            return new ActivityHiscoreModel
            {
                Rank = int.Parse(splitData[0]),
                Score = int.Parse(splitData[1])
            };
        }

        public static bool TryParse(string data, out ActivityHiscoreModel hiScore)
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

        private string DebuggerDisplay => $"S:{Score} | R:{Rank:N0}";
    }
}