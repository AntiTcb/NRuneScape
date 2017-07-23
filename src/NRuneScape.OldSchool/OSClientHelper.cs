using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Rest;

namespace NRuneScape.OldSchool
{
    internal static class OSClientHelper
    {                                                                   
        // Hiscores
        public static async Task<OSHiscoreCharacter> GetCharacterAsync(OSRestClient client, string accountName, GameMode mode)
        {
            var model = await client.ApiClient.GetCharacterAsync(accountName, EnumUtils.GetRoute(mode));
            if (model == null)
                return null;

            var entity = new OSHiscoreCharacter(client, model);
            return entity;
        }

        // Grand Exchange
        public static async Task<Item> GetItemAsync(OSRestClient client, int itemId)
        {
            var model = await client.ApiClient.GetItemAsync(itemId);
            if (model == null)
                return null;

            var entity = new Item(client, Game.OldSchool, model);
            return entity;
        }
        public static IAsyncEnumerable<Item> GetItemsAsync(OSRestClient client, string name, int? limit)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (limit < 0)
                throw new ArgumentOutOfRangeException($"{nameof(limit)} must be greater than 0.");
                                                   
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
                    var models = await client.ApiClient.GetItemsAsync(name, args: args);
                    return models
                        .Select(model => new Item(client, Game.OldSchool, model))
                        .ToReadOnlyCollection(() => models.Count);
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
