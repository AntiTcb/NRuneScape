using System;
using NRuneScape.OldSchool;

namespace NRunescape.OldSchool.Tests
{
    public class ClientFixture : IDisposable
    {
        public OSRestClient Client { get; internal set; }

        public ClientFixture() 
            => Client = new OSRestClient();

        public void Dispose() => Client?.Dispose();
    }
}
