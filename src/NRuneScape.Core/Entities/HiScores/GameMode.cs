using System;

namespace NRuneScape
{
    [Flags]                                       
    public enum GameMode : byte
    {
        [Route("")]
        Regular = 1,
        [Route("_ironman")]
        Ironman = 2,
        [Route("_ultimate")]
        UltimateIronman = 4,
        [Route("_hardcore_ironman")]
        HardcoreIronman = 8,
        [Route("_deadman")]
        Deadman = 16,
        [Route("_seasonal")]
        DeadmanSeasonal = 32
    }
}
