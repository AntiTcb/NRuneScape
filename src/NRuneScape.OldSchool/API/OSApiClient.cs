using RestEase;
using System;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool.API
{
    internal class OSApiClient : IDisposable
    {
        internal IOSApi API => RestClient.For<IOSApi>();
        internal RestClient RestClient { get; }
        protected bool _isDisposed;
        const string BASE_URI = "http://services.runescape.com";

        public OSApiClient() : this(new RestClient(BASE_URI) { ResponseDeserializer = new HiscoreCharacterDeserializer() }) { }

        public OSApiClient(RestClient client)
        {
            RestClient = client;
        }
                                    
        public void Dispose() => Dispose(true);

        internal virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    (API as IDisposable)?.Dispose();
                }
                _isDisposed = true;
            }
        }

        internal async Task<HiscoreCharacter> GetCharacterAsync(string accountName, OSGameMode gameMode)
        {
            try
            {
                switch (gameMode)
                {
                    case OSGameMode.Regular:
                        return await API.GetOSRSCharacterAsync(accountName).ConfigureAwait(false);

                    case OSGameMode.Ironman:
                        return await API.GetIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSGameMode.UltimateIronman:
                        return await API.GetUltimateIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSGameMode.HardcoreIronman:
                        return await API.GetHardcoreIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSGameMode.Deadman:
                        return await API.GetDeadmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSGameMode.DeadmanSeasonal:
                        return await API.GetDeadmanSeasonalCharacterAsync(accountName).ConfigureAwait(false);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(gameMode));
                }
            }
            catch (ApiException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}