using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.OldSchool.API;

namespace NRuneScape.OldSchool
{
    internal static class OSClientHelper
    {                                                                         
        static string GE_ROUTE => EnumUtils.GetGERoute(Game.OldSchool);

        // Hiscores
        public static async Task<OSHiscoreCharacter> GetCharacterAsync(OldSchoolRestClient client, string accountName, GameMode mode)
        {
            var model = await client.ApiClient.GetCharacterAsync(accountName, EnumUtils.GetRoute(mode));
            if (model == null)
                return null;

            var entity = new OSHiscoreCharacter(client, model);
            return entity;
        }

        // Grand Exchange
        public static async Task<OSItem> GetItemAsync(OldSchoolRestClient client, int itemId)
        {
            var model = await client.ApiClient.GetItemAsync(itemId);
            if (model == null)
                return null;

            var entity = new OSItem(client, model);
            return entity;
        }
        public static IAsyncEnumerable<OSItem> GetItemsAsync(OldSchoolRestClient client, string name, int? limit)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (limit < 0)
                throw new ArgumentOutOfRangeException($"{nameof(limit)} must be greater than 0.");
                                                   
            return new PagedAsyncEnumerable<OSItem>(
                RuneScapeConfig.MaxItemsPerPage,
                async (info, ct) =>
                {
                    var args = new GetItemParams
                    {
                        Limit = info.PageSize
                    };
                    if (info.Position != null)
                        args.AfterPageNum = info.Page + 1;
                    var models = await client.ApiClient.GetItemsAsync(name, GE_ROUTE, args);
                    return models
                        .Select(model => new OSItem(client, model))
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
