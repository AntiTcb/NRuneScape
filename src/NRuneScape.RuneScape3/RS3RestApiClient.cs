﻿using System.Net;
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
        internal Task<ItemModel[]> GetItemsAsync(string itemName, int categoryId, GetItemParams args, RequestOptions options)
            => GetItemsAsync(API.GERoute, itemName, categoryId, args, options);
        internal async override Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string hsRoute, string gameMode, RequestOptions options)
            => await GetCharacterAsync(accountName, gameMode, options);
    }
}
