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

        public async Task<OSRSCharacter> GetCharacterAsync(string accountName)
            => await GetCharacterAsync(accountName, OSRSGameMode.Regular);

        public async Task<OSRSCharacter> GetCharacterAsync(string accountName, OSRSGameMode gameMode)
        {
            var model = await ApiClient.GetCharacterAsync(accountName, gameMode);
            if (model == null)
                return null;

            var entity = new OSRSCharacter(this, model);
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