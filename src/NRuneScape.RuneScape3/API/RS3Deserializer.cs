using System;
using System.Linq;
using System.Net.Http;
using NRuneScape.API;

namespace NRuneScape.RuneScape3.API
{
    internal class RS3Deserializer : RestDeserializer
    {
        public override T Deserialize<T>(string content, HttpResponseMessage response)
        {
            if (typeof(T) == typeof(HiscoreCharacterModel))
                return DeserializeCharacter<T>(content, response.RequestMessage.RequestUri);
            if (typeof(T) == typeof(ClanMemberModel[]))
                return DeserializeClan<T>(content);

            return base.Deserialize<T>(content, response);
        }

        private T DeserializeClan<T>(string content)
        {
            var splitData = content.Split('n', StringSplitOptions.RemoveEmptyEntries).Skip(1);
            var members = splitData.Select(x => ClanMemberModel.Parse(x.Split(','))).ToArray();
            return ChangeType<T>(members);
        }

        protected override T DeserializeCharacter<T>(string content, Uri requestUri)
        {
            string username = GetUsername(requestUri);
            var model = new HiscoreCharacterModel(username, ParseGameModeUrl(requestUri), RS3HiscoreData.Parse(content));
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
