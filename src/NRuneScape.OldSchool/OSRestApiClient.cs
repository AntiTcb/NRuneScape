using System.Net;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Rest;
using RestEase;

namespace NRuneScape.OldSchool.API
{
    internal class OSRestApiClient : RuneScapeRestApiClient
    {
        public new IOSRestApi API { get; }

        public OSRestApiClient()
        {
            API = new RestClient(_httpClient) { ResponseDeserializer = new OSDserializer() }.For<IOSRestApi>();
            API.GERoute = EnumUtils.GetGERoute(Game.OldSchool);
            API.HiscoresRoute = EnumUtils.GetHiscoreRoute(Game.OldSchool);
        }

        internal async Task<HiscoreCharacter> GetCharacterAsync(string accountName, string gameMode, RequestOptions options)
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

        internal Task<ItemModel> GetItemAsync(int itemId, RequestOptions options)
            => GetItemAsync(API.GERoute, itemId, options);
        internal Task<ItemModel[]> GetItemsAsync(string itemName, GetItemParams args, RequestOptions options)
            => GetItemsAsync(API.GERoute, itemName, (int)GECategory.Ammo, args, options);
        internal async override Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string hsRoute, string gameMode, RequestOptions options)
            => await GetCharacterAsync(accountName, gameMode, options);
    }
}
