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
        internal new OSRestApiClient ApiClient { get; }

        /// <summary> Creates a new REST OldSchool RuneScape client. </summary>
        public OSRestClient(RuneScapeRestConfig config = null)
            : this(config ?? RuneScapeRestConfig.Default, new OSRestApiClient()) { }

        internal OSRestClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
            : base(config, client) => ApiClient = client as OSRestApiClient;

        /// <summary>
        /// Gets the <see cref="OSHiscoreCharacter"/> with the given name and game mode, or null if not found.
        /// </summary>
        public Task<OSHiscoreCharacter> GetCharacterAsync(string accountName, GameMode gameMode = GameMode.Regular, RequestOptions options = null)
            => OSClientHelper.GetCharacterAsync(this, accountName, gameMode, options ?? RequestOptions.Default);

        /// <summary>
        /// Gets the <see cref="Item"/> with the provided item ID, or null if not found.
        /// </summary>
        public Task<Item> GetItemAsync(int itemId, RequestOptions options = null)
            => ClientHelper.GetItemAsync(this, itemId, Game.OldSchool, options ?? RequestOptions.Default);

        /// <summary>
        /// Returns an asynchronous collection of <see cref="Item"/> whose names start with the provided string.
        /// </summary>
        public IAsyncEnumerable<Item> GetItemsAsync(string name, int? limit = null, RequestOptions options = null)
            => ClientHelper.GetItemsAsync(this, name, Game.OldSchool, GECategory.Ammo, limit, options ?? RequestOptions.Default);

    }
}