using System.Collections.Generic;
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
            API = new RestClient(RuneScapeConfig.APIUrl) { ResponseDeserializer = new RS3Deserializer() }
                .For<IRS3RestApi>();
            API.GERoute = EnumUtils.GetGERoute(Game.RuneScape3);
            API.HiscoresRoute = EnumUtils.GetHiscoreRoute(Game.RuneScape3);
            API.BestiaryRoute = "itemdb_rs/bestiary";
        }

        internal async Task<HiscoreCharacter> GetCharacterAsync(string accountName, string gameMode)
        {
            try
            {
                API.GameMode = gameMode;
                var resp = await API.GetCharacterAsync(accountName);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        internal Task<ItemModel> GetItemAsync(int itemId)
            => GetItemAsync(itemId, API.GERoute);
        internal Task<IReadOnlyCollection<ItemModel>> GetItemsAsync(string itemName, GetItemParams args, int categoryId)
            => GetItemsAsync(itemName, API.GERoute, categoryId, args);
        internal async override Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string hsRoute, string gameMode)
            => await GetCharacterAsync(accountName, gameMode);
    }
}
