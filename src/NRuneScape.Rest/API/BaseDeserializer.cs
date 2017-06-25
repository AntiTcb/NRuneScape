using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using RestEase;

namespace NRuneScape.API
{
    internal abstract class BaseDeserializer : IResponseDeserializer
    {
        internal JsonSerializerSettings JsonSerializerSettings { get; set; }
        public abstract T Deserialize<T>(string content, HttpResponseMessage response);
        protected abstract T DeserializeCharacter<T>(string content, Uri requestUri);

        protected virtual T DeserializeItem<T>(string content)
        {
            var dummy = new { Name = "", Item = default(T) };
            var model = JsonConvert.DeserializeAnonymousType(content, dummy);

            return model.Item;
        }

        protected virtual T DeserializeItems<T>(string content)
        {
            var dummy = new { Total = 0, Items = default(T) };
            var model = JsonConvert.DeserializeAnonymousType(content, dummy);

            return model.Items;
        }

        protected string GetUsername(Uri requestUri)
        {
            var queries = requestUri.Query.TrimStart('?')
                .Split('&')
                .Select(x => x.Split('='))
                .ToDictionary(key => key[0], value => value[1]);

            if (!queries.TryGetValue("player", out string username))
                throw new ArgumentNullException("Username was undefined.");

            return username.Replace('+', ' ').ToTitleCase();
        }

        protected T ChangeType<T>(object obj)
            => (T)Convert.ChangeType(obj, typeof(T));
    }
}
