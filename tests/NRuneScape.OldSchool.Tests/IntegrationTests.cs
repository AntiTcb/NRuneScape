using System;
using System.Threading.Tasks;
using Xunit;

namespace NRuneScape.OldSchool.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task Test1()
        {
            var osrsClient = new OldSchoolApiClient();

            var item = osrsClient.GetItemAsync(50);

            Assert.NotNull(item);
        }
    }
}
