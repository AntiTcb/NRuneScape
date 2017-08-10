using Newtonsoft.Json;

namespace NRuneScape.API
{
    internal class CategoryModel
    {
        [JsonProperty("types")]
        public object[] Types { get; set; }
        [JsonProperty("alpha")]
        public CategoryInfoModel[] Details { get; set; }
    }

    internal class CategoryInfoModel
    {
        [JsonProperty("letter")]
        public char Letter { get; set; }
        [JsonProperty("Items")]
        public int ItemCount { get; set; }
    }
}
