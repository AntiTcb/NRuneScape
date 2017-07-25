using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NRuneScape.Rest.Tests
{
    public class Tests : IClassFixture<ClientFixture>
    {
        internal ClientFixture _fixture;
        internal RuneScapeRestClient _client => _fixture.Client;

        public Tests(ClientFixture fixture)                         
            => _fixture = fixture;

        [Theory(DisplayName = "Item Stress Test")]
        [InlineData(4151, Game.OldSchool, true)]
        [InlineData(1232, Game.RuneScape3, false)]
        public async Task GetItemByIdTheory(int itemId, Game game, bool isValidInput)
        {
            var item = await _client.GetItemAsync(itemId, game);
            Assert.Equal(isValidInput, item != null);
        }

        [Fact]
        public async Task GetRS3AbyssalWhipById_ReturnAbyssalWhipEntity()
        {
            var rs3Whip = await _client.GetItemAsync(4151, Game.RuneScape3);
            Assert.True(rs3Whip.Name == "Abyssal whip");
            Assert.True(rs3Whip.GameSource == Game.RuneScape3);
        }

        [Fact]
        public async Task GetOSAbyssalWhipById_ReturnAbyssalWhipEntity()
        {
            var osWhip = await _client.GetItemAsync(4151, Game.OldSchool);
            Assert.True(osWhip.Name == "Abyssal whip");
            Assert.True(osWhip.GameSource == Game.OldSchool);
        }

        [Fact]
        public async Task GetRS3AbyssalWhipByName_ReturnAbyssalWhipInCollection()
        {
            var items = _client.GetItemsAsync("Abyssal", Game.RuneScape3, GECategory.HighLevelMeleeWeapons);
            var abyssalWhip = await items.FirstOrDefault(x => x.Name == "Abyssal whip" || x.Id == 4151);
            Assert.True(abyssalWhip.Name == "Abyssal whip");
            Assert.True(abyssalWhip.Id == 4151);
            Assert.True(await items.Count() == 1);
        }

        [Fact]
        public async Task GetCharacter_ThrowsNotSupportedException()
        {
            var chara = await (_client as IRuneScapeClient).GetCharacterAsync("anti-tcb", Game.OldSchool, GameMode.Regular);
            Assert.Null(chara);
        }

        [Fact]
        public async Task GetGEUpdateTime_IsValid()
        {
            var osTime = await _client.GetUpdateTimeAsync(Game.OldSchool);
            var rs3Time = await _client.GetUpdateTimeAsync(Game.RuneScape3);

            Assert.True(osTime.Value.Days <= RuneDate.Now.Value.Days);
            Assert.True(rs3Time.Value.Days <= RuneDate.Now.Value.Days);
        }

        internal void Dispose() => _client.Dispose();
    }
}
