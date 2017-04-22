namespace NRuneScape
{
    public interface ICharacter : IUpdateable
    {
        /// <summary> Gets the name for this character. </summary>
        string Name { get; }
    }
}