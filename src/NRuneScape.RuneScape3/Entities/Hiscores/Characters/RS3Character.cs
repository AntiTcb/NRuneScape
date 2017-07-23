using System.Diagnostics;
using NRuneScape.Rest;

namespace NRuneScape.RuneScape3
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class RS3Character : RestEntity<RS3RestClient>, ICharacter
    {
        /// <summary> Gets the account name for this character. </summary>
        public string Name { get; internal set; }

        internal RS3Character(RS3RestClient client) : base(client, Game.RuneScape3) { }

        private string DebuggerDisplay => $"({Name} | {GameSource})";
    }
}
