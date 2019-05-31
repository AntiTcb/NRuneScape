using Voltaic.Serialization;

namespace NRuneScape.Entities
{
    #nullable disable
    public class Category
    {
        [ModelProperty("types")]
        public object[] Types { get; set; }

        [ModelProperty("alpha")]
        public CategoryInfo[] Details { get; set; }
    }
    public class CategoryInfo
    {
        [ModelProperty("letter")]
        public char Letter { get; set; }
        [ModelProperty("items")]
        public int ItemCount { get; set; }
    }
}
