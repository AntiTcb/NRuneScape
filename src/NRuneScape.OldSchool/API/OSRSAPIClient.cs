using RestEase;
using System;
using System.Threading.Tasks;

namespace NRuneScape.OldSchool.API
{
    internal class OSRSAPIClient : IDisposable
    {
        internal IOSRSAPI API => RestClient.For<IOSRSAPI>();
        internal RestClient RestClient { get; }
        protected bool _isDisposed;
        const string BASE_URI = "http://services.runescape.com";

        public OSRSAPIClient() : this(new RestClient(BASE_URI) { ResponseDeserializer = new CharacterDeserializer() }) { }

        public OSRSAPIClient(RestClient client)
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

        internal async Task<Character> GetCharacterAsync(string accountName, OSRSGameMode gameMode)
        {
            try
            {
                switch (gameMode)
                {
                    case OSRSGameMode.Regular:
                        return await API.GetOSRSCharacterAsync(accountName).ConfigureAwait(false);

                    case OSRSGameMode.Ironman:
                        return await API.GetIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSRSGameMode.UltimateIronman:
                        return await API.GetUltimateIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSRSGameMode.HardcoreIronman:
                        return await API.GetHardcoreIronmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSRSGameMode.Deadman:
                        return await API.GetDeadmanCharacterAsync(accountName).ConfigureAwait(false);

                    case OSRSGameMode.DeadmanSeasonal:
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