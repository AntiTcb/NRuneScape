using RestEase;
using System;
using System.Threading.Tasks;
using NRuneScape.RuneScape3.API.Hiscores;

namespace NRuneScape.RuneScape3.API
{
    internal class RS3ApiClient : IDisposable
    {
        internal IRS3HiscoresApi Hiscores => RestClient.For<IRS3HiscoresApi>();
        internal RestClient RestClient { get; }
        protected bool _isdisposed;
        const string BASE_URI = "http://services.runescape.com";

        public RS3ApiClient() : this(new RestClient(BASE_URI)) { }

        public RS3ApiClient(RestClient client)
        {
            RestClient = client;
        }

        public void Dispose() => Dispose(true);

        internal virtual void Dispose(bool disposing)
        {

        }
    }
}
