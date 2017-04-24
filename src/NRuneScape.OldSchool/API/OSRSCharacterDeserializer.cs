using RestEase;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace NRuneScape.OldSchool.API
{                                                            
    internal class CharacterDeserializer : IResponseDeserializer
    {
        public T Deserialize<T>(string content, HttpResponseMessage response)
        {
            if (typeof(T) != typeof(HiscoreCharacter))
                throw new InvalidOperationException($"{nameof(T)} is not {nameof(HiscoreCharacter)}");

            var queries = response.RequestMessage.RequestUri.Query.TrimStart('?').Split('&').Select(x => x.Split('='));
            var keyedQueries = queries.ToDictionary(key => key[0], value => value[1]);

            if (!keyedQueries.TryGetValue("player", out string username))
                throw new ArgumentNullException("Username was not defined.");

            var gameMode = ParseGameModeUrl(response.RequestMessage.RequestUri.AbsolutePath);
            var returnAccount = new HiscoreCharacter(username.Replace('+', ' ').ToTitleCase(), gameMode, OSRSCharacterParser.ParseHiScoreData(content, OSGameMode.Regular));
            return (T)Convert.ChangeType(returnAccount, typeof(T));
        }                                           

        private OSGameMode ParseGameModeUrl(string url) {
            switch (url) {
                case "/m=hiscore_oldschool/index_lite.ws": return OSGameMode.Regular;
                case "/m=hiscore_oldschool_ironman/index_lite.ws": return OSGameMode.Ironman;
                case "/m=hiscore_oldschool_hardcore_ironman/index_lite.ws": return OSGameMode.HardcoreIronman;
                case "/m=hiscore_oldschool_ultimate/index_lite.ws": return OSGameMode.UltimateIronman;
                case "/m=hiscore_oldschool_deadman/index_lite.ws": return OSGameMode.Deadman;
                case "/m=hiscore_oldschool_seasonal/index_lite.ws": return OSGameMode.DeadmanSeasonal;
                default: throw new InvalidOperationException($"{nameof(url)} could not be parsed to a game mode.");
            }
        }
    }
}