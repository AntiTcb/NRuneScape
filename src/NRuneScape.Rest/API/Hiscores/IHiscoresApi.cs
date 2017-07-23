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
        Task<Response<IHiscoreCharacterModel>> GetCharacterAsync([Query("player")]string accountName);

        [Get("m={hsRoute}{gameMode}/ranking.json")]
        Task<Response<object>> GetTopRankedAsync([Query] int table,
                                                 [Query] int category,
                                                 [Query("size")] int limit);
    }
}
