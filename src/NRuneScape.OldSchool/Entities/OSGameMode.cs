using System;

namespace NRuneScape.OldSchool
{
    [Flags]
    public enum OSGameMode : byte
    {
        Regular = 1,
        Ironman = 2,
        UltimateIronman = 4,
        HardcoreIronman = 8,
        Deadman = 16,
        DeadmanSeasonal = 32
    }
}