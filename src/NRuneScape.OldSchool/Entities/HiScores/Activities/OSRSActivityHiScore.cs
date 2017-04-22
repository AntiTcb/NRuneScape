using System.Diagnostics;
using Model = NRuneScape.OldSchool.API.ActivityHiScore;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSRSActivityHiScore : IActivityHiScore, IOSRSHiScore
    {
        public OSRSGameMode GameMode { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }
        public int Score { get; private set; }

        internal static OSRSActivityHiScore Create(Model model, OSRSActivity name, OSRSGameMode gameMode)
        {
            return new OSRSActivityHiScore
            {
                Name = name.GetFullActivityName(),
                GameMode = gameMode,
                Rank = model.Rank,
                Score = model.Score
            };
        }

        private string DebuggerDisplay => $"({Name} | {GameMode}) S:{Score} | R:{Rank:N0}";
    }
}