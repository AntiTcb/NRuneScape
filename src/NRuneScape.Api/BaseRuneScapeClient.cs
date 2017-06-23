using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;

namespace NRuneScape.Rest
{
    public abstract class BaseRuneScapeClient : IRuneScapeClient 
    {
        // TODO: Logging?   
        internal RuneScapeRestApiClient ApiClient { get; }
        private bool _isDisposed;                  

        /// <summary> Creates a new RuneScape client. </summary>
        internal BaseRuneScapeClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
        {
            ApiClient = client;
        }

        internal abstract Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode);

        /// <summary>
        /// Disposes this client object. 
        /// </summary>
        public void Dispose() => Dispose(true);

        internal virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                ApiClient.Dispose();
                _isDisposed = true;
            }
        }

        Task<IHiscoreCharacter> IRuneScapeClient.GetCharacterAsync(string accountName, Game game, GameMode mode)
            => Task.FromResult<IHiscoreCharacter>(null);
        Task<IItem> IRuneScapeClient.GetItemAsync(int itemId, Game game)
            => Task.FromResult<IItem>(null);
        IAsyncEnumerable<IItem> IRuneScapeClient.GetItemsAsync(string name, Game game, int? limit)
            => AsyncEnumerable.Empty<IItem>();
    }
}
