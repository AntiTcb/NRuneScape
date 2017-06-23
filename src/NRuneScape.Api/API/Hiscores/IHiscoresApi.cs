using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    /// <summary>
    /// The interface providing REST endpoints for the Hiscores for RuneScape.
    /// </summary>
    internal interface IHiscoresApi : IRuneScapeApi
    {
        [Get("m={route}{gameMode}/index_lite.ws")]
        Task<Response<BaseCharacter>> GetCharacterAsync([Path]string route, [Path]string gameMode, [Query("player")]string accountName);
    }
}
