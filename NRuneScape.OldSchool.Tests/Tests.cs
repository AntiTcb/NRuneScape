using System;
using System.Threading.Tasks;
using Xunit;                

namespace NRuneScape.OldSchool.Tests
{
    public class Tests : IDisposable
    {
        internal readonly OSClient _client;

        public Tests()
        {
            _client = new OSClient();
        }

        [Fact]
        public async Task GetRegular_IsAntiTcb_ReturnsAccount()
        {
            var account = await _client.GetCharacterAsync("anti-tcb");
            Assert.True(account.Name == "Anti-tcb");
            Assert.True(account.Agility.Level == 72);
        }      

        [Fact]
        public async Task GetIronman_IsAntiTcbAndNoIronmanCharacterExists_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.Ironman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetHardcoreIronMan_IsAntiTcbAndDoesNotExist_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.HardcoreIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetUltimateIronman_IsAntiTcbAndDoesNotExist_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.UltimateIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetDeadman_IsAntiTcb_ReturnsAccount()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.Deadman);
            Assert.True(account.Overall.Level == 114);
        }

        [Fact]
        public async Task GetSeasonal_IsAntiTcb_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.DeadmanSeasonal);
            Assert.Null(account);
        }

        [Fact]
        public async Task GetRegularSlayer_IsAntiTcb_Returns63()
        {
            var account = await _client.GetCharacterAsync("antitcb", OSGameMode.Regular);
            Assert.True(account.Slayer.Level == 63);
        }

        [Fact]
        public async Task GetRegularMasterClues_IsAntiTcb_ReturnsNull()
        {
            var account = await _client.GetCharacterAsync("anti-tcb", OSGameMode.Regular);
            Assert.Null(account.ClueScrollsMaster.Score);
            Assert.Null(account.ClueScrollsMaster.Rank);
        } 

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
