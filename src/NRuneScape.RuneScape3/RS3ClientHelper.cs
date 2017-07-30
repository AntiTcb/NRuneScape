using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Rest;

namespace NRuneScape.RuneScape3
{
    internal static class RS3ClientHelper
    {
        // Hiscores
        public static async Task<RS3HiscoreCharacter> GetCharacterAsync(RS3RestClient client, string accountName, GameMode mode, RequestOptions options)
        {
            string gameMode = EnumUtils.GetRoute(mode);

            switch (mode)
            {
                case GameMode.Regular:
                case GameMode.Ironman:
                case GameMode.HardcoreIronman:
                    var model = await client.ApiClient.GetCharacterAsync(accountName, gameMode, options);
                    if (model == null)
                        return null;

                    var entity = new RS3HiscoreCharacter(client, model);
                    return entity;
                
                default:
                    throw new NotSupportedException($"RuneScape 3 does not support {nameof(GameMode)}{mode}");
            }
        }

        // Grand Exchange
        public static async Task<Item> GetItemAsync(RS3RestClient client, int itemId, RequestOptions options)
        {
            var model = await client.ApiClient.GetItemAsync(itemId, options);
            if (model == null)
                return null;

            var entity = new Item(client, Game.RuneScape3, model);
            return entity;
        }
        public static IAsyncEnumerable<Item> GetItemsAsync(RS3RestClient client, string name, int categoryId, int? limit, RequestOptions options)
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
                    var models = await client.ApiClient.GetItemsAsync(name, categoryId, args, options);
                    return models
                        .Select(model => new Item(client, Game.RuneScape3, model))
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
    }
}
