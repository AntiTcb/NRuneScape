using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.RuneScape3.API
{
    internal interface IRS3BestiaryApi : IRuneScapeApi
    {
        [Path("bestiaryRoute")]
        string BestiaryRoute { get; set; }

        [Get("m={bestiaryRoute}/beastData.json")]
        Task<Response<BeastDataModel>> GetBeastDataAsync([Query] int beastId, CancellationToken ct);
        [Get("m={bestiaryRoute}/beastSearch.json")]
        Task<Response<LabelValueModel[]>> GetBeastSearchAsync([Query] string term, CancellationToken ct);
        [Get("m={bestiaryRoute}/beastiaryNames.json")]
        Task<Response<LabelValueModel[]>> GetBestiaryNamesAsync([Query] char letter, CancellationToken ct);
        [Get("m={bestiaryRoute}/areaNames.json")]
        Task<Response<string[]>> GetAreaNamesAsync(CancellationToken ct);
        [Get("m={bestiaryRoute}/areaBeasts.json")]
        Task<Response<LabelValueModel[]>> GetAreaBeastsAsync([Query] string identifier, CancellationToken ct);
        [Get("m={bestiaryRoute}/slayerCatNames.json")]
        Task<Response<Dictionary<string, int>>> GetSlayerCategoriesAsync(CancellationToken ct);
        [Get("m={bestiaryRoute}/slayerBeasts.json")]
        Task<Response<LabelValueModel[]>> GetSlayerMonstersAsync([Query] int identifier, CancellationToken ct);
        [Get("m={bestiaryRoute}/weaknessNames.json")]
        Task<Response<Dictionary<string, int>>> GetSlayerWeaknessesAsync(CancellationToken ct);
        [Get("m={bestiaryRoute}/weaknessBeasts.json")]
        Task<Response<LabelValueModel[]>> GetMonstersByWeaknessAsync([Query] int identifier, CancellationToken ct);
        [Get("m={bestiaryRoute}/levelGroup.json")]
        Task<Response<LabelValueModel[]>> GetMonstersBetweenLevelsAsync([Query] string identifer, CancellationToken ct);
    }
}
