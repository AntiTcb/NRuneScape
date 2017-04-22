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
            if (typeof(T) != typeof(Character))
                throw new InvalidOperationException($"{nameof(T)} is not {nameof(Character)}");

            var queries = response.RequestMessage.RequestUri.Query.TrimStart('?').Split('&').Select(x => x.Split('='));
            var keyedQueries = queries.ToDictionary(key => key[0], value => value[1]);

            if (!keyedQueries.TryGetValue("player", out string username))
                throw new ArgumentNullException("Username was not defined.");

            var gameMode = ParseGameModeUrl(response.RequestMessage.RequestUri.AbsolutePath);
            var returnAccount = new Character(username.Replace('+', ' ').ToTitleCase(), gameMode, OSRSCharacterParser.ParseHiScoreData(content, OSRSGameMode.Regular));
            return (T)Convert.ChangeType(returnAccount, typeof(T));
        }                                           

        private OSRSGameMode ParseGameModeUrl(string url) {
            switch (url) {
                case "/m=hiscore_oldschool/index_lite.ws": return OSRSGameMode.Regular;
                case "/m=hiscore_oldschool_ironman/index_lite.ws": return OSRSGameMode.Ironman;
                case "/m=hiscore_oldschool_hardcore_ironman/index_lite.ws": return OSRSGameMode.HardcoreIronman;
                case "/m=hiscore_oldschool_ultimate/index_lite.ws": return OSRSGameMode.UltimateIronman;
                case "/m=hiscore_oldschool_deadman/index_lite.ws": return OSRSGameMode.Deadman;
                case "/m=hiscore_oldschool_seasonal/index_lite.ws": return OSRSGameMode.DeadmanSeasonal;
                default: throw new InvalidOperationException($"{nameof(url)} could not be parsed to a game mode.");
            }
        }
    }
}