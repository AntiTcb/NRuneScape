namespace NRuneScape
{
    /// <summary>
    /// The base interface for all hiscore values.
    /// </summary>
    public interface IHiscore
    {                                             
        /// <summary>
        /// Gets the name of this hiscore value.
        /// </summary>
        string Name { get; }               
        /// <summary>
        /// Gets the rank of this hiscore value.
        /// </summary>
        int? Rank { get; }
    }
}