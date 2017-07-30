using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{
    internal static class OSClientHelper
    {
        // Hiscores
        public static async Task<OSHiscoreCharacter> GetCharacterAsync(OSRestClient client, string accountName, GameMode mode, RequestOptions options)
        {
            string gameMode = EnumUtils.GetRoute(mode);

            var model = await client.ApiClient.GetCharacterAsync(accountName, gameMode, options);
            if (model == null)
                return null;

            var entity = new OSHiscoreCharacter(client, model);
            return entity;
        }
    }
}
