using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    internal interface IGrandExchangeApi : IRuneScapeApi
    {
        [Path("geRoute")]
        string GERoute { get; set; }

        [Get("m={geRoute}/api/catalogue/category.json")]
        Task<Response<CategoryModel>> GetCategoryInfoAsync([Query("category")] int categoryId, CancellationToken ct);

        [Get("m={geRoute}/api/catalogue/detail.json")]
        Task<Response<ItemModel>> GetItemAsync([Query("item")] int itemId, CancellationToken ct);
        [Get("m={geRoute}/api/catalogue/items.json")]
        Task<Response<ItemModel[]>> GetItemsAsync([Query("alpha")] string itemQuery,
                                                  [Query("page")] int pageNum, 
                                                  [Query("category")] int category, CancellationToken ct);

        [Get("m={geRoute}/api/graph/{itemId}.json")]
        Task<Response<GraphModel>> GetItemGraphAsync([Path] int itemId, CancellationToken ct);

        [Get("m={geRoute}/obj_{imageSize}.gif")]
        Task<Response<Stream>> GetItemImageAsync([Path] string imageSize, [Query("id")] int itemId, CancellationToken ct);

        [Get("m={geRoute}/api/info.json")]
        Task<Response<RuneDateModel>> GetUpdateTimeAsync(CancellationToken ct);
    }
}