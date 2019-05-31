using System;
using System.Threading.Tasks;
using NRuneScape.Entities;
using RestEase;

namespace NRuneScape
{
    internal interface IRuneScapeApiClient : IDisposable
    {
        [Path("ge_route")]
        string GERoute { get; set; }

        // HiScores

        // Grand Exchange
        Task<CategoryInfo> GetCategoryInfoAsync();

        [Get("m={ge_route}/api/catalogue/detail.json")]
        Task<Item> GetItemAsync([Query("item")] int itemId);
        [Get("m={ge_route}/api/catalogue/items.json")]
        Task<Item[]> GetItemsAsync([QueryMap] GetItemsParams args);

        // Bestiary
        // RuneMetrics
        // Solomon's
        // Website
    }
}
