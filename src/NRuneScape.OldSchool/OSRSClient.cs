using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{
    /// <summary>
    /// A client for interacting with OldSchool Runescape data sources.
    /// </summary>
    public class OSRSClient : IRSClient
    {
        internal API.OSRSAPIClient ApiClient { get; }

        /// <summary>
        /// Creates a new REST OldSchool RuneScape client.
        /// </summary>
        public OSRSClient() 
            => ApiClient = new API.OSRSAPIClient(); 

        /// <summary>
        /// Gets the <see cref="OSHiscoreCharacter"/> with the given name and game mode, or null if not found.
        /// </summary>                                                                                                         
        public async Task<OSHiscoreCharacter> GetCharacterAsync(string accountName, OSGameMode gameMode = OSGameMode.Regular)
        {
            var model = await ApiClient.GetCharacterAsync(accountName, gameMode);
            if (model == null)
                return null;

            var entity = new OSHiscoreCharacter(this, model);
            return entity;
        }     
        /// <summary>
        /// Gets the <see cref="OSSkillHiscore"/> with the given name, skill, and game mode, or null if not found.
        /// </summary>
        public async Task<OSSkillHiscore> GetSkillAsync(string accountName, OSSkill skill, OSGameMode gameMode = OSGameMode.Regular)
        {
            var character = await ApiClient.GetCharacterAsync(accountName, gameMode);
            var entity = character?.Skills[skill];
            return entity;
        }

        /// <summary>
        /// Gets the <see cref="OSActivityHiscore"/> with the given name, activity, and game mode, or null if not found.
        /// </summary>
        public async Task<OSActivityHiscore> GetActivityAsync(string accountName, OSActivity activity, OSGameMode gameMode = OSGameMode.Regular)
        {
            var character = await ApiClient.GetCharacterAsync(accountName, gameMode);
            var entity = character?.Activities[activity];
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