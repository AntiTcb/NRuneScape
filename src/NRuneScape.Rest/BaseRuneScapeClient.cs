using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.API;
using NRuneScape.Logging;

namespace NRuneScape.Rest
{
    public abstract class BaseRuneScapeClient : IRuneScapeClient
    {
        public event Func<LogMessage, Task> Log {
            add => _logEvent.Add(value);
            remove => _logEvent.Remove(value);
        }
        private readonly AsyncEvent<Func<LogMessage, Task>> _logEvent = new AsyncEvent<Func<LogMessage, Task>>();

        internal readonly Logger _restLogger;
        internal LogManager LogManager { get; }

        internal RuneScapeRestApiClient ApiClient { get; }
        private bool _isDisposed;

        /// <summary> Creates a new RuneScape client. </summary>
        internal BaseRuneScapeClient(RuneScapeRestConfig config, RuneScapeRestApiClient client)
        {
            ApiClient = client;
            LogManager = new LogManager(config.LogLevel);
            LogManager.Message += async msg => await _logEvent.InvokeAsync(msg).ConfigureAwait(false);

            _restLogger = LogManager.CreateLogger("Rest");
            ApiClient.SentRequest += async (method) => await _restLogger.VerboseAsync($"GET {method}").ConfigureAwait(false);
        }

        internal abstract Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode, RequestOptions options = null);

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

        Task<IHiscoreCharacter> IRuneScapeClient.GetCharacterAsync(string accountName, Game game, GameMode mode, RequestOptions options)
            => Task.FromResult<IHiscoreCharacter>(null);
        Task<IItem> IRuneScapeClient.GetItemAsync(int itemId, Game game, RequestOptions options)
            => Task.FromResult<IItem>(null);
        IAsyncEnumerable<IItem> IRuneScapeClient.GetItemsAsync(string name, Game game, int? limit, RequestOptions options)
            => AsyncEnumerable.Empty<IItem>();
    }
}
