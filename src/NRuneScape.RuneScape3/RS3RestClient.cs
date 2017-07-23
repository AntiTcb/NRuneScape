using System.Collections.Generic;
using System.Threading.Tasks;
using NRuneScape;
using NRuneScape.API;
using NRuneScape.Rest;
using NRuneScape.RuneScape3.API;

namespace NRuneScape.RuneScape3
{
    /// <summary> A client for interacting with RuneScape 3 data sources. </summary>
    public class RS3RestClient : RuneScapeRestClient, IRuneScapeClient
    {                                           
        internal new RS3RestApiClient ApiClient { get; }

        /// <summary> Creates a new REST RuneScape 3 client. </summary>
        public RS3RestClient()
            : this(new RuneScapeRestConfig(),
                   new RS3RestApiClient())
        { }

        internal RS3RestClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
            : base(config, client)
            => ApiClient = client as RS3RestApiClient;

        /// <summary>
        /// Gets the <see cref="API.HiscoreCharacter"/> with the given name and game mode, or null if not found.
        /// </summary>                                                                                                         
        public Task<RS3HiscoreCharacter> GetCharacterAsync(string accountName, GameMode gameMode = GameMode.Regular)
            => RS3ClientHelper.GetCharacterAsync(this, accountName, gameMode);

        /// <summary>
        /// Gets the <see cref="Item"/> with the provided item ID, or null if not found.
        /// </summary>                                               
        public Task<Item> GetItemAsync(int itemId)
            => ClientHelper.GetItemAsync(this, itemId, Game.RuneScape3);

        /// <summary>
        /// Returns an asynchronous collection of <see cref="RS3Item"/> whose names start with the provided string.
        /// </summary>
        public IAsyncEnumerable<Item> GetItemsAsync(string name, int? limit = null)
            => ClientHelper.GetItemsAsync(this, name, Game.RuneScape3, limit);

    }
}
