using System;
using System.Linq;
using System.Threading.Tasks;
using NRuneScape.Rest;
using Xunit;

namespace NRuneScape.API.Tests
{
    public class Tests : IDisposable
    {
        internal readonly RuneScapeRestClient _client;

        public Tests()
        {
            _client = new RuneScapeRestClient();
        }

        [Theory]
        [InlineData(4151)]
        [InlineData(1232)]
        public async Task GetItemByIdTheory(int itemId)
        {
            var item = await _client.GetItemAsync(itemId, Game.OldSchool);
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetRS3AbyssalWhipById_ReturnAbyssalWhipEntity()
        {
            var rs3Whip = await _client.GetItemAsync(4151, Game.RuneScape3);
            Assert.True(rs3Whip.Name == "Abyssal whip");
            Assert.IsType<RSItem>(rs3Whip);
        }

        [Fact]
        public async Task GetOSAbyssalWhipById_ReturnAbyssalWhipEntity()
        {
            var osWhip = await _client.GetItemAsync(4151, Game.OldSchool);
            Assert.True(osWhip.Name == "Abyssal whip");
            Assert.IsType<RSItem>(osWhip);
        }

        [Fact]
        public async Task GetRS3AbyssalWhipByName_ReturnAbyssalWhipInCollection()
        {
            var items = _client.GetItemsAsync("Abyssal whip", Game.RuneScape3);
            var abyssalWhip = await items.FirstOrDefault(x => x.Name == "Abyssal whip" || x.Id == 4151);
            Assert.True(abyssalWhip.Name == "Abyssal whip");
            Assert.True(abyssalWhip.Id == 4151);
            Assert.True(await items.Count() == 0);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
