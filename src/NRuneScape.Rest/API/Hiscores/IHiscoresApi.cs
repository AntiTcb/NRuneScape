using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    /// <summary>
    /// The interface providing REST endpoints for the Hiscores for RuneScape.
    /// </summary>
    internal interface IHiscoresApi : IRuneScapeApi
    {
        [Path("hsRoute")]
        string HiscoresRoute { get; set; }
        [Path("gameMode")]
        string GameMode { get; set; }

        [Get("m={hsRoute}{gameMode}/index_lite.ws")]
        Task<Response<ICharacterModel>> GetCharacterAsync([Query("player")]string accountName);
    }
}
