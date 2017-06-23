using System.IO;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    /// <summary>
    /// The interface providing REST endpoints for the Grand Exchange for RuneScape.
    /// </summary>
    internal interface IGrandExchangeApi : IRuneScapeApi
    {
        [Path("geRoute")]
        string GERoute { get; set; }

        [Get("m={geRoute}/api/catalogue/detail.json")]
        Task<Response<Item>> GetItemByIdAsync([Query("item")] int itemId);

        [Get("m={geRoute}/api/catalogue/items.json?category=1")]
        Task<Response<Item[]>> GetItemByNameAsync([Query("alpha")] string itemName, 
            [Query("page")] int pageNum = 1);
                                             
        [Get("m={geRoute}/api/graph/{itemId}.json")]
        Task<Response<Stream>> GetItemGraphAsync([Path] int itemId);
                                           
        [Get("m={geRoute}/obj_{imageSize}.gif")]
        Task<Response<Stream>> GetItemImageAsync([Path] string imageSize, [Query("id")] int itemId);
    }
}
