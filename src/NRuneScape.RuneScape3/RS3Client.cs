using System.Threading.Tasks;

namespace NRuneScape.RuneScape3
{
    public class RS3Client : IRSClient
    {
        internal API.RS3ApiClient ApiClient { get; }

        public RS3Client()
            => ApiClient = new API.RS3ApiClient();

        public async Task<RS3HiscoreCharacter> GetCharacterAsync(string accountName, RS3GameMode gameMode = RS3GameMode.Regular)
        {

        }

        Task<ICharacter> IRSClient.GetCharacterAsync(string accountName)
            => Task.FromResult<ICharacter>(null);
    }
}
