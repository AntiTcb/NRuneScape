using RestEase;
using System;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool.API
{
    internal interface IOSRSAPI : IDisposable
    {
        [Get("m=hiscore_oldschool_deadman/index_lite.ws")]
        Task<HiscoreCharacter> GetDeadmanCharacterAsync([Query("player")] string accountName);

        [Get("m=hiscore_oldschool_seasonal/index_lite.ws")]
        Task<HiscoreCharacter> GetDeadmanSeasonalCharacterAsync([Query("player")] string accountName);

        [Get("m=hiscore_oldschool_hardcore_ironman/index_lite.ws")]
        Task<HiscoreCharacter> GetHardcoreIronmanCharacterAsync([Query("player")] string accountName);

        [Get("m=hiscore_oldschool_ironman/index_lite.ws")]
        Task<HiscoreCharacter> GetIronmanCharacterAsync([Query("player")] string accountName);

        [Get("m=hiscore_oldschool/index_lite.ws")]
        Task<HiscoreCharacter> GetOSRSCharacterAsync([Query("player")] string accountName);

        [Get("m=hiscore_oldschool_ultimate/index_lite.ws")]
        Task<HiscoreCharacter> GetUltimateIronmanCharacterAsync([Query("player")] string accountName);
    }
}