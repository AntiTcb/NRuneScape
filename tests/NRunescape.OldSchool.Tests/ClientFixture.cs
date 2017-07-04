using System;
using NRuneScape.OldSchool;

namespace NRunescape.OldSchool.Tests
{
    public class ClientFixture : IDisposable
    {
        public OldSchoolRestClient Client { get; internal set; }
        public ClientFixture()
        {
            Client = new OldSchoolRestClient();
        }
        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
