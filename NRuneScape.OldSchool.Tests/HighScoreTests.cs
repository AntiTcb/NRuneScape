using System;
using System.Threading.Tasks;
using Xunit;                

namespace NRuneScape.OldSchool.Tests
{
    public class HighScoreTests : IDisposable
    {
        internal readonly OSRSClient _client;
        const string accountName = "anti-tcb";

        public HighScoreTests()
        {
            _client = new OSRSClient();
        }

        [Fact]
        public async Task GetRegular_IsAntiTcb_ReturnsAccount()
        {
            var account = await _client.GetCharacterAsync(accountName);
            Assert.True(account.Name == "Anti-tcb");
            Assert.True(account.Agility.Level == 72);
        }      

        [Fact]
        public async Task GetIronman_IsAntiTcbAndNoIronmanCharacterExists_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync(accountName, OSGameMode.Ironman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetHardcoreIronMan_IsAntiTcbAndDoesNotExist_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync(accountName, OSGameMode.HardcoreIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetUltimateIronman_IsAntiTcbAndDoesNotExist_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync(accountName, OSGameMode.UltimateIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetDeadman_IsAntiTcb_ReturnsAccount()
        {
            var account = await _client.GetCharacterAsync(accountName, OSGameMode.Deadman);
            Assert.True(account.Overall.Level == 114);
        }

        [Fact]
        public async Task GetSeasonal_IsAntiTcb_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync(accountName, OSGameMode.DeadmanSeasonal);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetRegularSlayer_IsAntiTcb_Returns63()
        {
            var account = await _client.GetCharacterAsync("antitcb", OSGameMode.Regular);
            Assert.True(account.Slayer.Level == 63);
        }

        [Fact]
        public async Task GetRegularMasterClues_IsAntiTcb_ReturnsNegative1()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.Regular);
            Assert.True(account.ClueScrollsMaster.Score == -1);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
