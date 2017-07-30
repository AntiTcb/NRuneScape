using System;

namespace NRuneScape.OldSchool.Tests
{
    public class ClientFixture : IDisposable
    {
        public OSRestClient Client { get; internal set; }

        public ClientFixture() 
            => Client = new OSRestClient(new Rest.RuneScapeRestConfig { LogLevel = LogSeverity.Debug });

        public void Dispose() => Client?.Dispose();
    }
}
