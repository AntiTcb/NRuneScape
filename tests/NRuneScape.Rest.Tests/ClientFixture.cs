using System;

namespace NRuneScape.Rest.Tests
{
    public class ClientFixture : IDisposable
    {
        public RuneScapeRestClient Client { get; internal set; }

        public ClientFixture()
            => Client = new RuneScapeRestClient();

        public void Dispose() => Client?.Dispose();
    }
}
