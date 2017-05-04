using System.Diagnostics;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class OSCharacter : RestEntity, IOSCharacter
    {
        /// <summary> Gets the game mode for this character. </summary>
        public OSGameMode GameMode { get; internal set; }
        /// <summary> Gets the account name for this character. </summary>
        public string Name { get; internal set; }

        internal OSCharacter(OSClient client) : base(client) { }

        private string DebuggerDisplay => $"({Name} | {GameMode})";       
    }
}