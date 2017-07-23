using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.OldSchool.API
{
    internal interface IOSHiscoresApi : IHiscoresApi
    {
        [Get("m={hsRoute}{gameMode}/index_lite.ws")]
        new Task<Response<HiscoreCharacter>> GetCharacterAsync([Query("player")]string accountName);
    }
}
