using System.Diagnostics;
using Model = NRuneScape.API.ActivityHiscoreModel;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ActivityHiscore : IActivityHiscore
    {
        /// <summary> Gets the activity name for this hiscore. </summary>
        public string Name { get; private set; }        
        /// <summary> Gets the rank for this hiscore. Returns null if unranked. </summary>
        public int? Rank 
        {
            get => _rank != -1 ? _rank : default(int?);
            private set => _rank = value ?? -1;
        }
        /// <summary> Gets the score for this hiscore. Returns null if unranked. </summary>
        public int? Score 
        {
            get => _score != -1 ? _score : default(int?);
            private set => _score = value ?? -1;
        }

        internal static ActivityHiscore Create(Model model, Activity name) => new ActivityHiscore
        {
            Name = EnumUtils.GetInfo(name).Name,
            Rank = model.Rank,
            Score = model.Score
        };

        public void Deconstruct(out string name, out int? score, out int? rank)
        {
            name = Name;
            score = Score;
            rank = Rank;
        }    
        private string DebuggerDisplay => $"({Name}) S:{Score} | R:{Rank:N0}";
        private int _rank;
        private int _score;
    }
}