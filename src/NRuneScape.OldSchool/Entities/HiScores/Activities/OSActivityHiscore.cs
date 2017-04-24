using System.Diagnostics;
using Model = NRuneScape.OldSchool.API.ActivityHiScore;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSActivityHiscore : IActivityHiscore, IOSRSHiScore
    {                 
        /// <summary> Gets the game mode of the account for this hiscore. </summary>
        public OSGameMode GameMode { get; private set; }
        /// <summary> Gets the activity name for this hiscore. </summary>
        public string Name { get; private set; }
        /// <summary> Gets the rank for this hiscore. Returns null if unranked. </summary>
        public int? Rank { get; private set; }
        /// <summary> Gets the score for this hiscore. Returns null if unranked. </summary>
        public int? Score { get; private set; }

        internal static OSActivityHiscore Create(Model model, OSActivity name, OSGameMode gameMode)
        {
            return new OSActivityHiscore
            {
                Name = name.ToActivityName(),
                GameMode = gameMode,
                Rank = model.Rank,
                Score = model.Score
            };
        }

        public void Deconstruct(out string name, out OSGameMode mode, out int? score, out int? rank)
        {
            name = Name;
            mode = GameMode;
            score = Score;
            rank = Rank;
        }

        public void Deconstruct(out string name, out int? score, out int? rank)
        {
            name = Name;
            score = Score;
            rank = Rank;
        }    

        private string DebuggerDisplay => $"({Name} | {GameMode}) S:{Score} | R:{Rank:N0}";
    }
}