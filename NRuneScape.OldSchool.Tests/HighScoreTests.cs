using System;
using System.Threading.Tasks;
using Xunit;
using NRuneScape.OldSchool;

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
        public async Task Test_GetRegularCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName);
            Assert.True(account.Name == "Anti-tcb");
            Assert.True(account.Agility.Level == 72);
        }      

        [Fact]
        public async Task Test_GetIronmanCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName, OSRSGameMode.Ironman);
            Assert.Null(account);
        }

        [Fact]
        public async Task Test_GetHardcoreIronmanCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName, OSRSGameMode.HardcoreIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task Test_GetUltimateIronmanCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName, OSRSGameMode.UltimateIronman);
            Assert.Null(account);
        }

        [Fact]
        public async Task Test_GetDeadmanCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName, OSRSGameMode.Deadman);
            Assert.True(account.Overall.Level == 114);
        }

        [Fact]
        public async Task Test_GetDeadmanSeasonalCharacter()
        {
            var account = await _client.GetCharacterAsync(accountName, OSRSGameMode.DeadmanSeasonal);
            Assert.Null(account);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
