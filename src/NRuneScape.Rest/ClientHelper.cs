using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Rest;

namespace NRuneScape
{
    internal static class ClientHelper
    {
        // Grand Exchange
        // TODO: RequestOptions
        public static async Task<IReadOnlyCollection<CategoryInfo>> GetCategoryInfoAsync(RuneScapeRestClient client, Game game, GECategory category, RequestOptions options)
        {
            string route = EnumUtils.GetGERoute(game);

            var model = await client.ApiClient.GetCategoryInfoAsync(route, (int)category, options).ConfigureAwait(false);
            if (model == null)
                return null;

            var entities = model.Select(x => new CategoryInfo(client, game, x))
            .ToReadOnlyCollection(() => model.Length);
            return entities;
        }
        public static async Task<Item> GetItemAsync(RuneScapeRestClient client, int itemId, Game game, RequestOptions options)
        {
            string route = EnumUtils.GetGERoute(game);

            var model = await client.ApiClient.GetItemAsync(route, itemId, options).ConfigureAwait(false);
            if (model == null)
                return null;

            var entity = new Item(client, game, model);
            return entity;
        }
        public static IAsyncEnumerable<Item> GetItemsAsync(RuneScapeRestClient client, string name, Game game, GECategory category, int? limit, RequestOptions options)
        {
            if (game == Game.OldSchool && category != GECategory.Ammo)
                throw new NotSupportedException($"Old School RuneScape only accepts the {nameof(GECategory.Ammo)} category.");

            string route = EnumUtils.GetGERoute(game);

            return new PagedAsyncEnumerable<Item>(
                RuneScapeConfig.MaxItemsPerPage,
                async (info, ct) =>
                {
                    var args = new GetItemParams { Limit = info.PageSize };
                    if (info.Position != null)
                        args.AfterPageNum = info.Page + 1;

                    var models = await client.ApiClient.GetItemsAsync(route, name, (int)category, args, options);
                    return models
                        .Select(model => new Item(client, game, model))
                        .ToReadOnlyCollection(() => models.Length);
                },

                nextPage: (info, lastPage) =>
                {
                    if (lastPage.Count != RuneScapeConfig.MaxItemsPerPage)
                        return false;
                    info.Position = lastPage.Count;
                    return true;
                },

                count: limit
            );
        }
        public static async Task<Stream> GetItemImageAsync(RuneScapeRestClient client, int itemId, Game game, ItemImageSize size, RequestOptions options)
        {
            string route = EnumUtils.GetGERoute(game);
            string imageSize = EnumUtils.GetInfo(size).Name;

            var model = await client.ApiClient.GetItemImageAsync(route, itemId, imageSize, options).ConfigureAwait(false);
            if (model == null)
                return null;

            // TODO: Clone stream?
            return model;
        }
        public static async Task<RuneDate?> GetUpdateTimeAsync(RuneScapeRestClient client, Game game, RequestOptions options)
        {
            string route = EnumUtils.GetGERoute(game);

            var model = await client.ApiClient.GetUpdateTimeAsync(route, options).ConfigureAwait(false);
            if (model == null)
                return null;

            var entity = new RuneDate(model);
            return entity;
        }
    }
}
