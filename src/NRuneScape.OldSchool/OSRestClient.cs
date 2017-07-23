using System.Collections.Generic;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.OldSchool.API;
using NRuneScape.Rest;

namespace NRuneScape.OldSchool
{
    /// <summary>
    /// A client for interacting with OldSchool Runescape data sources.
    /// </summary>
    public class OSRestClient : RuneScapeRestClient, IRuneScapeClient
    {   
        internal new OldSchoolRestApiClient ApiClient { get; }

        /// <summary> Creates a new REST OldSchool RuneScape client. </summary>
        public OSRestClient()
            : this(new RuneScapeRestConfig(), 
                   new OldSchoolRestApiClient()) { }

        internal OSRestClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
            : base(config, client) 
            => ApiClient = client as OldSchoolRestApiClient;

        /// <summary>
        /// Gets the <see cref="OSHiscoreCharacter"/> with the given name and game mode, or null if not found.
        /// </summary>                                                                                                         
        public Task<OSHiscoreCharacter> GetCharacterAsync(string accountName, GameMode gameMode = GameMode.Regular)
            => OSClientHelper.GetCharacterAsync(this, accountName, gameMode);
                                                    
        /// <summary>
        /// Gets the <see cref="OSItem"/> with the provided item ID, or null if not found.
        /// </summary>                                               
        public Task<Item> GetItemAsync(int itemId)
            => ClientHelper.GetItemAsync(this, itemId, Game.OldSchool);
        
        /// <summary>
        /// Returns an asynchronous collection of <see cref="OSItem"/> whose names start with the provided string.
        /// </summary>
        public IAsyncEnumerable<Item> GetItemsAsync(string name, int? limit = null)
            => ClientHelper.GetItemsAsync(this, name, Game.OldSchool, GECategory.Ammo, limit);
        
    }
}