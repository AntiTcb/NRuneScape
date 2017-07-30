using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NRuneScape.OldSchool.Tests
{
    public class Tests : IClassFixture<ClientFixture>
    {
        internal ClientFixture _fixture;
        internal OSRestClient _client => _fixture.Client;

        public Tests(ClientFixture fixture)
        {
            _fixture = fixture;
            _client.Log += (m) => { Debug.WriteLine(m.ToString()); return Task.CompletedTask; };
        }

        [Fact(DisplayName = "Anti-Tcb Regular")]
        public async Task GetRegularAsync_ReturnsValidCharacter()
        {
            var account = await _client.GetCharacterAsync("anti-tcb");
            Assert.True(account.Name == "Anti-tcb");
            Assert.True(account.Agility.Level == 75);
        }

        [Fact(DisplayName = "Anti-Tcb Ironman")]
        public async Task GetIronmanAsync_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.Ironman);
            Assert.Null(account);
        }

        [Fact(DisplayName = "Anti-Tcb Hardcore")]
        public async Task GetHardcoreIronman_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.HardcoreIronman);
            Assert.Null(account);
        }

        [Fact(DisplayName = "Anti-Tcb Ultimate")]
        public async Task GetUltimateIronman_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.UltimateIronman);
            Assert.Null(account);
        }

        [Fact(DisplayName = "Anti-Tcb Deadman")]
        public async Task GetDeadman_ReturnsValidCharacter()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.Deadman);
            Assert.True(account.Overall.Level == 114);
        }

        [Fact(DisplayName = "Anti-Tcb Seasonal") ]
        public async Task GetSeasonal_RetunsValidCharacter()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.DeadmanSeasonal);
            Assert.NotNull(account);
        }

        [Fact(DisplayName = "AntiTcb Regular Slayer")]
        public async Task GetSlayerLevel_Returns63()
        {
            var account = await _client.GetCharacterAsync("antitcb", GameMode.Regular);
            Assert.True(account.Slayer.Level == 63);
        }

        [Fact(DisplayName = "Anti-Tcb Master Clues")]
        public async Task GetMasterClues_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", GameMode.Regular);
            Assert.Null(account.ClueScrollsMaster.Score);
            Assert.Null(account.ClueScrollsMaster.Rank);
        }

        [Fact(DisplayName = "Abyssal Whip")]
        public async Task GetAbyssalWhip_ReturnsValidItem()
        {
            var item = await _client.GetItemAsync(4151);
            Assert.True(item.Name == "Abyssal whip");
            Assert.True(item.IsMembersItem);
            Assert.True(item.Description == "A weapon from the abyss.");
        }

        [Fact(DisplayName = "Rune items")]
        public async Task GetRuneItems_ReturnsValidCollection()
        {
            var items = _client.GetItemsAsync("rune", 60);
            Assert.True(await items.Count() == 60);
            var item = await _client.GetItemAsync(1319);
        }

        [Theory(DisplayName = "Item Stress Test")]
        [InlineData(4151, true)]
        [InlineData(9999999, false)]
        public async Task GetItemTheory(int itemId, bool isValidInput)
        {
            var item = await _client.GetItemAsync(itemId);
            Assert.Equal(isValidInput, item != null);
        }

        internal void Dispose() => _client.Dispose();
    }
}
