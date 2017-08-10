using System;

namespace NRuneScape.RuneScape3.API
{
    internal class ClanMemberModel
    {
        public string Username { get; set; }
        public ClanRanking Rank { get; set; }
        public ulong Experience { get; set; }
        public int KillCount { get; set; }

        public static ClanMemberModel Parse(string[] data) => new ClanMemberModel
        {
            Username = SanitizeUsername(data[0]),
            Rank = EnumUtils.Parse<ClanRanking>(data[1], true), 
            Experience = ulong.Parse(data[2]),
            KillCount = int.Parse(data[3])
        };

        public static bool TryParse(string[] data, out ClanMemberModel model)
        {
            model = null;
            if (!ulong.TryParse(data[2], out ulong exp) || 
                !int.TryParse(data[3], out int kc) || 
                !Enum.TryParse<ClanRanking>(data[1], true, out var rank))
                return false;

            model = new ClanMemberModel
            {
                Username = SanitizeUsername(data[0]),
                Rank = rank,
                Experience = exp,
                KillCount = kc
            };
            return true;
        }

        private static string SanitizeUsername(string username)
            => username.Replace('�', ' ');
    }
}
