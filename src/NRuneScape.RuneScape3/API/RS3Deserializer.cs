using System;
using System.Net.Http;
using NRuneScape.API;

namespace NRuneScape.RuneScape3.API
{
    internal class RS3Deserializer : RestDeserializer
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
            var model = new HiscoreCharacter(username, ParseGameModeUrl(requestUri), RS3HiscoreData.Parse(content));
            return ChangeType<T>(model);

            GameMode ParseGameModeUrl (Uri url)
            {
                switch (url.LocalPath)
                {
                    case "/m=hiscore/index_lite.ws": return GameMode.Regular;
                    case "/m=hiscore_ironman/index_lite.ws": return GameMode.Ironman;
                    case "/m=hiscore_hardcore_ironman/index_lite.ws": return GameMode.HardcoreIronman;
                    default: throw new InvalidOperationException($"{nameof(url)} could not be parsed to a game mode.");
                }
            }
        }
    }
}
