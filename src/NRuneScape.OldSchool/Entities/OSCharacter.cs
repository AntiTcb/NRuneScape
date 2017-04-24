using System;             
using System.Diagnostics;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{ 
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class OSCharacter : RestEntity, IOSCharacter
    {
        public OSGameMode GameMode { get; internal set; }
        public string Name { get; internal set; }

        internal OSCharacter(OSRSClient client) : base(client) { }
                                                                  
        public virtual Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        private string DebuggerDisplay => $"({Name} | {GameMode})";       
    }
}