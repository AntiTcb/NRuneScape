using System;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{
    public class OSRSClient : IRSClient
    {
        internal API.OSRSAPIClient ApiClient { get; }

        public OSRSClient()
        {
            ApiClient = new API.OSRSAPIClient();
        }

        public async Task<OSHiscoreCharacter> GetCharacterAsync(string accountName)
            => await GetCharacterAsync(accountName, OSGameMode.Regular);

        public async Task<OSHiscoreCharacter> GetCharacterAsync(string accountName, OSGameMode gameMode)
        {
            var model = await ApiClient.GetCharacterAsync(accountName, gameMode);
            if (model == null)
                return null;

            var entity = new OSHiscoreCharacter(this, model);
            return entity;
        }

        public void Dispose()
        {
            ApiClient.Dispose();
        }

        Task<ICharacter> IRSClient.GetCharacterAsync(string accountName)
            => Task.FromResult<ICharacter>(null);
    }
}