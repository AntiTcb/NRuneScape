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
        Task<Response<BeastDataModel>> GetBeastDataAsync([Query] int beastId);

        [Get("m={bestiaryRoute}/beastSearch.json")]
        Task<Response<LabelValueModel[]>> GetBeastSearchAsync([Query] string term);

        [Get("m={bestiaryRoute}/beastiaryNames.json")]
        Task<Response<LabelValueModel[]>> GetBestiaryNamesAsync([Query] char letter);

        [Get("m={bestiaryRoute}/areaNames.json")]
        Task<Response<string[]>> GetAreaNamesAsync();

        [Get("m={bestiaryRoute}/areaBeasts.json")]
        Task<Response<LabelValueModel[]>> GetAreaBeastsAsync([Query] string identifier);

        [Get("m={bestiaryRoute}/slayerCatNames.json")]
        Task<Response<(string CategoryName, int CategoryId)[]>> GetSlayerCategoriesAsync();

        [Get("m={bestiaryRoute}/slayerBeasts.json")]
        Task<Response<LabelValueModel[]>> GetMonstersBySlayerCategoryAsync([Query] int identifier);

        [Get("m={bestiaryRoute}/weaknessNames.json")]
        Task<Response<(string WeaknessName, int WeaknessId)[]>> GetSlayerWeaknessesAsync();

        [Get("m={bestiaryRoute}/weaknessBeasts.json")]
        Task<Response<LabelValueModel[]>> GetMonstersByWeaknessAsync([Query] int identifier);

        [Get("m={bestiaryRoute}/levelGroup.json")]
        Task<Response<LabelValueModel[]>> GetMonstersBetweenLevelsAsync([Query] string identifer);
    }
}
