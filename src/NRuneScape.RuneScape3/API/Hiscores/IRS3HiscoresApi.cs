using System.Threading;
using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.RuneScape3.API
{
    internal interface IRS3HiscoresApi : IHiscoresApi<HiscoreCharacterModel>
    {
        [Get("m=temp-hiscores/getRankings.json")]
        Task<Response<SeasonalRankingModel[]>> GetSeasonalRankingAsync([Query("player")] string accountName, [Query("status")] string archived, CancellationToken ct);
        [Get("m=temp-hiscores/getHiscoreDetails.json")]
        Task<Response<SeasonalDetailsModel[]>> GetSeasonalDetailsAsync([Query("status")] string archived, CancellationToken ct);
        [Get("m=clan-hiscores/clanRanking.json")]
        Task<Response<ClanRankingModel[]>> GetTopThreeClansAsync(CancellationToken ct);
        [Get("m=clan-hiscores/members_lite.ws")]
        Task<Response<ClanMemberModel[]>> GetClanMembersAsync([Query("clanName")] string clanName, CancellationToken ct);
    }
}
