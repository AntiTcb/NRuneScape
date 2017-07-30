using System;

namespace NRuneScape.RuneScape3.Tests
{
    public class ClientFixture : IDisposable
    {
        public RS3RestClient Client { get; internal set; }

        public ClientFixture()
            => Client = new RS3RestClient(new Rest.RuneScapeRestConfig { LogLevel = LogSeverity.Debug });

        public void Dispose() => Client?.Dispose();
    }
}
