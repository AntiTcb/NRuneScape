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
        public static async Task<RSItem> GetItemAsync(RuneScapeRestClient client, int itemId, Game game)
        {
            var model = await client.ApiClient.GetItemByIdAsync(itemId, EnumUtils.GetGERoute(game));
            if (model == null)
                return null;

            var entity = new RSItem(client, game, model);
            return entity;
        }
        public static IAsyncEnumerable<RSItem> GetItemsAsync(RuneScapeRestClient client, string name, Game game, int? limit)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (limit < 0)
                throw new ArgumentOutOfRangeException($"{nameof(limit)} must be greater than 0.");

            var route = EnumUtils.GetGERoute(game);
                                         
            return new PagedAsyncEnumerable<RSItem>(
                RuneScapeConfig.MaxItemsPerPage,
                async (info, ct) =>
                {
                    var args = new GetItemParams
                    {
                        Limit = info.PageSize
                    };
                    if (info.Position != null)
                        args.AfterPageNum = info.Page + 1;
                    var models = await client.ApiClient.GetItemsByNameAsync(name, route, args);
                    return models
                        .Select(model => new RSItem(client, game, model))
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
