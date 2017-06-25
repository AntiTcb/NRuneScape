using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NRuneScape.API;
using RestEase;

namespace NRuneScape.OldSchool.API
{
    internal class OldSchoolRestApiClient : RuneScapeRestApiClient
    {
        public new IOSRestApi API { get; }
        public OldSchoolRestApiClient() 
        {
            API = new RestClient(RuneScapeConfig.APIUrl) { ResponseDeserializer = new OSDserializer() }
                .For<IOSRestApi>();
            API.GERoute = EnumUtils.GetGERoute(Game.OldSchool);
            API.HiscoresRoute = EnumUtils.GetHiscoreRoute(Game.OldSchool);
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

        internal Task<Item> GetItemAsync(int itemId)
            => GetItemAsync(itemId, API.GERoute);
        internal Task<IReadOnlyCollection<Item>> GetItemsAsync(string itemName, GetItemParams args)
            => GetItemsAsync(itemName, API.GERoute, args);
        internal async override Task<ICharacterModel> GetCharacterAsync(string accountName, string hsRoute, string gameMode)
            => await GetCharacterAsync(accountName, gameMode);
    }
}
