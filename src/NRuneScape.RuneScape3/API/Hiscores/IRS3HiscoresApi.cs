using System.Threading;
using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.RuneScape3.API
{
    internal interface IRS3HiscoresApi : IHiscoresApi<HiscoreCharacter>
    {
        [Get("m=temp-hiscores/getRankings.json")]
        Task<Response<object[]>> GetRankingAsync([Query("player")] string accountName, [Query("status")] string archived, CancellationToken ct);
        [Get("m=temp-hiscores/getHiscoreDetails.json")]
        Task<Response<object[]>> GetHiscoreDetailsAsync([Query("status")] string archived, CancellationToken ct);
        [Get("m=clan-hiscores/clanRanking.json")]
        Task<Response<object[]>> GetTopThreeClansAsync(CancellationToken ct);
        [Get("m=clan-hiscores/members_lite.ws")]
        Task<Response<object[]>> GetClanMembersAsync([Query("clanName")] string clanName, CancellationToken ct);
    }
}
