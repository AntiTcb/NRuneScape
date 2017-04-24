using System;             
using System.Diagnostics;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{ 
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class OSCharacter : RestEntity, IOSCharacter
    {
        /// <summary> Gets the game mode for this character. </summary>
        public OSGameMode GameMode { get; internal set; }
        /// <summary> Gets the account name for this character. </summary>
        public string Name { get; internal set; }

        internal OSCharacter(OSRSClient client) : base(client) { }
        /// <summary> Use a more derived type to update. Will throw a <see cref="NotImplementedException"/>.</summary>                        
        /// <exception cref="NotImplementedException">Thrown on all cases. Use a more derived type to update.</exception>
        public virtual Task UpdateAsync()
            => throw new NotImplementedException($"{nameof(OSCharacter)} cannot be updated, use a more derived type.");

        private string DebuggerDisplay => $"({Name} | {GameMode})";       
    }
}