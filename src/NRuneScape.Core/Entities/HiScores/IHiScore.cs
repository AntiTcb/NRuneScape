namespace NRuneScape
{
    public interface IHiscore
    {
        /// <summary> Gets the name for this hiscore. </summary>
        string Name { get; }                 
        /// <summary> Gets the rank for this hiscore. </summary>
        int Rank { get; }
    }
}