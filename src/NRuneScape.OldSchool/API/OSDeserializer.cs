using System;
using System.Net.Http;
using NRuneScape.API;

namespace NRuneScape.OldSchool.API
{
    internal class OSDserializer : RestDeserializer
    {
        public override T Deserialize<T>(string content, HttpResponseMessage response)
        {
            if (typeof(T) == typeof(HiscoreCharacter))
                return DeserializeCharacter<T>(content, response.RequestMessage.RequestUri);

            return base.Deserialize<T>(content, response);
        }

        protected override T DeserializeCharacter<T>(string content, Uri requestUri)
        {
            string username = GetUsername(requestUri);
            var model = new HiscoreCharacter(username, ParseGameModeUrl(requestUri), OSHiscoreData.Parse(content));
            return ChangeType<T>(model);


            GameMode ParseGameModeUrl(Uri url)
            {
                switch (url.LocalPath)
                {
                    case "/m=hiscore_oldschool/index_lite.ws": return GameMode.Regular;
                    case "/m=hiscore_oldschool_ironman/index_lite.ws": return GameMode.Ironman;
                    case "/m=hiscore_oldschool_hardcore_ironman/index_lite.ws": return GameMode.HardcoreIronman;
                    case "/m=hiscore_oldschool_ultimate/index_lite.ws": return GameMode.UltimateIronman;
                    case "/m=hiscore_oldschool_deadman/index_lite.ws": return GameMode.Deadman;
                    case "/m=hiscore_oldschool_seasonal/index_lite.ws": return GameMode.DeadmanSeasonal;
                    default: throw new InvalidOperationException($"{nameof(url)} could not be parsed to a game mode.");
                }
            }
        }
    }
}