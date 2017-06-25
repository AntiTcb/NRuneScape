using System;
using System.Collections.Generic;

namespace NRuneScape.OldSchool
{
    public interface IOSCharacter : ICharacter
    {
        /// <summary> Gets the game mode this character was created in. </summary>
        GameMode GameMode { get; }
    }
}