using System.IO;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{                   
    internal interface IGrandExchangeApi : IRuneScapeApi
    {
        [Path("geRoute")]
        string GERoute { get; set; }

        [Get("m={geRoute}/api/info.json")]
        Task<Response<RuneDateModel>> GetUpdateTimeAsync();

        [Get("m={geRoute}/api/catalogue/detail.json")]
        Task<Response<ItemModel>> GetItemAsync([Query("item")] int itemId);

        [Get("m={geRoute}/api/catalogue/category.json")]
        Task<Response<(string Letter, int Items)>> GetCategoryInfoAsync([Query("category")] int categoryId);

        [Get("m={geRoute}/api/catalogue/items.json")]
        Task<Response<ItemModel[]>> GetItemsAsync([Query("alpha")] string itemName, 
            [Query("page")] int pageNum = 1, [Query("category")] int category = 1);
                                             
        [Get("m={geRoute}/api/graph/{itemId}.json")]                                    
        Task<Response<GraphModel>> GetItemGraphAsync([Path] int itemId);
                                           
        [Get("m={geRoute}/obj_{imageSize}.gif")]
        Task<Response<Stream>> GetItemImageAsync([Path] string imageSize, [Query("id")] int itemId);
    }
}
