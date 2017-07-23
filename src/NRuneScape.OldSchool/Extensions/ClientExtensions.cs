using System.Threading.Tasks;

namespace NRuneScape.OldSchool
{
    public static class ClientExtensions
    {
        public static async Task<SkillHiscore> GetSkillAsync(this OSRestClient client, string accountName, Skill skill, GameMode mode = GameMode.Regular)
            => (await client.GetCharacterAsync(accountName, mode)).Skills[skill];
        public static async Task<ActivityHiscore> GetActivityAsync(this OSRestClient client, string accountName, Activity activity, GameMode mode = GameMode.Regular)
            => (await client.GetCharacterAsync(accountName, mode)).Activities[activity];
    }
}