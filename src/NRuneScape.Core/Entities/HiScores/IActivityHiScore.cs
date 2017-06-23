namespace NRuneScape
{
    public interface IActivityHiscore : IHiscore
    {                   
        /// <summary>
        /// The score in this activity hiscore value. Returns null if unranked.
        /// </summary>
        int? Score { get; } 
    }
}