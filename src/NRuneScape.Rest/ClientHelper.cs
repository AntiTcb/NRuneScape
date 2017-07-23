using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Rest;

namespace NRuneScape
{
    internal static class ClientHelper
    {
        // Grand Exchange
        public static async Task<Item> GetItemAsync(RuneScapeRestClient client, int itemId, Game game)
        {
            var model = await client.ApiClient.GetItemAsync(itemId, EnumUtils.GetGERoute(game));
            if (model == null)
                return null;

            var entity = new Item(client, game, model);
            return entity;
        }

        // Defaults to ammo as all Old School items are in category 1.
        public static IAsyncEnumerable<Item> GetItemsAsync(RuneScapeRestClient client, string name, Game game, int? limit, GECategory category = GECategory.Ammo)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));                                                                                                   
            if (limit < 0)
                throw new ArgumentOutOfRangeException($"{nameof(limit)} must be greater than 0.");
            if (game == Game.OldSchool && category != GECategory.Ammo)
                throw new NotSupportedException($"Old School RuneScape only accepts the {nameof(GECategory.Ammo)} category.");

            string route = EnumUtils.GetGERoute(game);
                                         
            return new PagedAsyncEnumerable<Item>(
                RuneScapeConfig.MaxItemsPerPage,
                async (info, ct) =>
                {
                    var args = new GetItemParams
                    {
                        Limit = info.PageSize
                    };
                    if (info.Position != null)
                        args.AfterPageNum = info.Page + 1;
                    var models = await client.ApiClient.GetItemsAsync(name, route, args, (int)category);
                    return models
                        .Select(model => new Item(client, game, model))
                        .ToImmutableArray();
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
    }
}
