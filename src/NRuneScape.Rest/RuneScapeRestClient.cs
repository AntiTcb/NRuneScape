using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NRuneScape.API;

namespace NRuneScape.Rest
{
    public class RuneScapeRestClient : BaseRuneScapeClient, IRuneScapeClient
    {
        public RuneScapeRestClient() 
            : this(new RuneScapeRestConfig(),
                  new RuneScapeRestApiClient(new RestDeserializer())) { }
        public RuneScapeRestClient(RuneScapeRestConfig config) 
            : this(config, new RuneScapeRestApiClient(new RestDeserializer())) { }

        internal RuneScapeRestClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
            : base(config, client) { }           

        /// <summary> Gets an item by id from the requested game. </summary>                                                                                       
        public Task<Item> GetItemAsync(int itemId, Game game)
            => ClientHelper.GetItemAsync(this, itemId, game);

        /// <summary> Gets a collection of items whose name start with the input query, from the requested game and Grand Exchange category. </summary>
        public IAsyncEnumerable<Item> GetItemsAsync(string itemName, Game game, GECategory category, int? limit = null)
            => ClientHelper.GetItemsAsync(this, itemName.ToLowerInvariant(), game, category, limit: limit);

        /// <summary> Gets the last update time for the Grand Exchange from the requested game. </summary>
        public Task<RuneDate> GetUpdateTimeAsync(Game game)
            => ClientHelper.GetUpdateTimeAsync(this, game);

        internal override Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode) 
            => throw new NotSupportedException("Characters cannot be retrieved using this client type.");

        //IRuneScapeClient
        Task<IHiscoreCharacter> IRuneScapeClient.GetCharacterAsync(string accountName, Game game, GameMode mode)
            => Task.FromResult<IHiscoreCharacter>(null);
        async Task<IItem> IRuneScapeClient.GetItemAsync(int itemId, Game game)
            => await GetItemAsync(itemId, game);
    }
}
