using System.Collections.Generic;
using NRuneScape.Requests;
using Voltaic.Serialization;

namespace NRuneScape
{
    public class GetItemsParams : QueryMap
    {
        [ModelProperty("alpha")]
        public string NameStartsWith { get; set; }
        [ModelProperty("category")]
        public int CategoryId { get; set; }
        [ModelProperty("page")]
        public int Page { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["alpha"] = NameStartsWith,
                ["category"] = CategoryId.ToString(),
                ["page"] = Page.ToString()
            };

            return map;
        }

        public void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("alpha", out string str))
                NameStartsWith = str;
            if (map.TryGetValue("category", out str))
                CategoryId = int.Parse(str);
            if (map.TryGetValue("page", out str))
                Page = int.Parse(str);
        }
    }
}