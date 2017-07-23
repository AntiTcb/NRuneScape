using System.Diagnostics;
using NRuneScape.Rest;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class OSCharacter : RestEntity<OSRestClient>, ICharacter
    {                                                                  
        /// <summary> Gets the account name for this character. </summary>
        public string Name { get; internal set; }

        internal OSCharacter(OSRestClient client) : base(client, Game.OldSchool) { }

        private string DebuggerDisplay => $"({Name} | {GameSource})";       
    }
}