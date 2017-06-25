using System.Diagnostics;
using NRuneScape.Rest;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class OSCharacter : RestEntity<OldSchoolRestClient>, IOSCharacter
    {                                                                  
        /// <summary> Gets the account name for this character. </summary>
        public string Name { get; internal set; }        
        /// <summary> Gets the game mode for this character. </summary>
        public GameMode GameMode { get; internal set; }

        internal OSCharacter(OldSchoolRestClient client) : base(client, Game.OldSchool) { }

        private string DebuggerDisplay => $"({Name} | {GameMode})";       
    }
}