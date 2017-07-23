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

        public async Task<Item> GetItemAsync(int itemId, Game game)
            => await ClientHelper.GetItemAsync(this, itemId, game);

        public IAsyncEnumerable<Item> GetItemsAsync(string itemName, Game game, GECategory category, int? limit = null)
            => ClientHelper.GetItemsAsync(this, itemName, game, category, limit: limit);

        internal override Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode) 
            => throw new NotSupportedException();

        //IRuneScapeClient
        Task<IHiscoreCharacter> IRuneScapeClient.GetCharacterAsync(string accountName, Game game, GameMode mode)
            => Task.FromResult<IHiscoreCharacter>(null);
        async Task<IItem> IRuneScapeClient.GetItemAsync(int itemId, Game game)
            => await GetItemAsync(itemId, game);
    }
}
