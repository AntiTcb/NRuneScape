using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.RuneScape3.API
{
    internal class RS3RestApiClient : RuneScapeRestApiClient
    {
        public new IRS3RestApi API { get; }

        public RS3RestApiClient()
        {
            API = new RestClient(_httpClient) { ResponseDeserializer = new RS3Deserializer() }.For<IRS3RestApi>();
            API.GERoute = EnumUtils.GetGERoute(Game.RuneScape3);
            API.HiscoresRoute = EnumUtils.GetHiscoreRoute(Game.RuneScape3);
            API.BestiaryRoute = "itemdb_rs/bestiary";
        }

        //Bestiary
        internal async Task<BeastDataModel> GetBeastDataAsync(int beastId, RequestOptions options)
        {
            Preconditions.AtLeast(beastId, 1, nameof(beastId));

            try
            {
                var resp = await API.GetBeastDataAsync(beastId, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetBeastSearchAsync(string term, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(term, nameof(term));

            try
            {
                var resp = await API.GetBeastSearchAsync(term, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetBestiaryNamesAsync(char letter, RequestOptions options)
        {
            try
            {
                var resp = await API.GetBestiaryNamesAsync(letter, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<string[]> GetAreaNamesAsync(RequestOptions options)
        {
            try
            {
                var resp = await API.GetAreaNamesAsync(options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetAreaBeastsAsync(string identifer, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(identifer, nameof(identifer));

            try
            {
                var resp = await API.GetAreaBeastsAsync(identifer, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<IReadOnlyDictionary<int, string>> GetSlayerCategoriesAsync(RequestOptions options)
        {
            try
            {
                var resp = await API.GetSlayerCategoriesAsync(options.CancelToken);
                return resp.GetContent().ToDictionary(k => k.Value, v => v.Key);
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetSlayerMonstersAsync(int categoryId, RequestOptions options)
        {
            Preconditions.AtLeast(categoryId, 1, nameof(categoryId));

            try
            {
                var resp = await API.GetSlayerMonstersAsync(categoryId, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<IReadOnlyDictionary<int, string>> GetSlayerWeaknessesAsync(RequestOptions options)
        {
            try
            {
                var resp = await API.GetSlayerWeaknessesAsync(options.CancelToken);
                return resp.GetContent().ToDictionary(k => k.Value, v => v.Key);
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetMonstersByWeaknessAsync(int weaknessId, RequestOptions options)
        {
            Preconditions.AtLeast(weaknessId, 1, nameof(weaknessId));

            try
            {
                var resp = await API.GetMonstersByWeaknessAsync(weaknessId, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<LabelValueModel[]> GetMonstersBetweenLevelsAsync(int minimum, int maximum, RequestOptions options)
        {
            Preconditions.AtLeast(minimum, 1, nameof(minimum));
            Preconditions.AtLeast(maximum, 1, nameof(minimum));
            Preconditions.AtMost(maximum, minimum, nameof(maximum), $"The minimum cannot be more than the maximum!");

            try
            {
                var resp = await API.GetMonstersBetweenLevelsAsync($"{minimum}-{maximum}", options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }

        //Hiscores
        internal async Task<HiscoreCharacterModel> GetCharacterAsync(string accountName, string gameMode, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(accountName, nameof(accountName));

            API.GameMode = gameMode;

            try
            {
                var resp = await API.GetCharacterAsync(accountName, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<IReadOnlyDictionary<string, SeasonalRankingModel[]>> GetSeasonalRankingAsync(string accountName, bool previousSeasonals, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(accountName, nameof(accountName));

            try
            {
                var resp = await API.GetSeasonalRankingAsync(accountName, previousSeasonals ? "archived" : null, options.CancelToken);
                return resp.GetContent()
                    .OrderBy(x => x.StartDate).GroupBy(x => x.SeasonalName)
                    .ToDictionary(k => k.Key, v => v.Select(x => x).ToArray());
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<IReadOnlyDictionary<string, SeasonalDetailsModel[]>> GetSeasonalDetailsAsync(bool previousSeasonals, RequestOptions options)
        {
            try
            {
                var resp = await API.GetSeasonalDetailsAsync(previousSeasonals ? "archived" : null, options.CancelToken);
                return resp.GetContent().OrderBy(x => x.StartDate).GroupBy(x => x.Title)
                .ToDictionary(x => x.Key, x => x.Select(y => y).ToArray());
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<ClanRankingModel[]> GetTopThreeClansAsync(RequestOptions options)
        {
            try
            {
                var resp = await API.GetTopThreeClansAsync(options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }

        //GE
        internal Task<ItemModel> GetItemAsync(int itemId, RequestOptions options)
            => GetItemAsync(API.GERoute, itemId, options);
        internal Task<ItemModel[]> GetItemsAsync(string itemName, int categoryId, GetItemParams args, RequestOptions options)
            => GetItemsAsync(API.GERoute, itemName, categoryId, args, options);
        internal async override Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string hsRoute, string gameMode, RequestOptions options)
            => await GetCharacterAsync(accountName, gameMode, options);
    }
}
