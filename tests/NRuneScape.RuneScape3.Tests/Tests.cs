using System.Threading.Tasks;
using Xunit;

namespace NRuneScape.RuneScape3.Tests
{
    public class Tests : IClassFixture<ClientFixture>
    {
        internal ClientFixture _fixture;
        internal RS3RestClient _client => _fixture.Client;

        public Tests(ClientFixture fixture)
            => _fixture = fixture;

        [Fact]
        public async Task GetAntiTcb_ReturnAccount()
        {
            var account = await _client.GetCharacterAsync("coloured");
            Assert.True(account.Attack.Level == 99);
        }
    }
}
