using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NRuneScape.API;

namespace NRuneScape.Rest
{
    public class RuneScapeRestClient : BaseRuneScapeClient, IRuneScapeClient
    {
        public RuneScapeRestClient(RuneScapeRestConfig config = null)
            : this(config ?? RuneScapeRestConfig.Default, new RuneScapeRestApiClient(new RestDeserializer())) { }

        internal RuneScapeRestClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
            : base(config, client) { }

        /// <summary> Gets an item by id from the requested game. </summary>
        public Task<Item> GetItemAsync(int itemId, Game game, RequestOptions options = null)
            => ClientHelper.GetItemAsync(this, itemId, game, options ?? RequestOptions.Default);

        /// <summary> Gets a collection of items whose name start with the input query, from the requested game and Grand Exchange category. </summary>
        public IAsyncEnumerable<Item> GetItemsAsync(string itemName, Game game, GECategory category, int? limit = null, RequestOptions options = null)
            => ClientHelper.GetItemsAsync(this, itemName.ToLowerInvariant(), game, category, limit, options ?? RequestOptions.Default);

        /// <summary> Gets the last update time for the Grand Exchange from the requested game. </summary>
        public Task<RuneDate?> GetUpdateTimeAsync(Game game, RequestOptions options = null)
            => ClientHelper.GetUpdateTimeAsync(this, game, options ?? RequestOptions.Default);

        internal override Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode, RequestOptions options = null)
            => throw new NotSupportedException("Characters cannot be retrieved using this client type.");

        //IRuneScapeClient
        Task<IHiscoreCharacter> IRuneScapeClient.GetCharacterAsync(string accountName, Game game, GameMode mode, RequestOptions options)
            => Task.FromResult<IHiscoreCharacter>(null);
        async Task<IItem> IRuneScapeClient.GetItemAsync(int itemId, Game game, RequestOptions options)
            => await GetItemAsync(itemId, game);
    }
}
