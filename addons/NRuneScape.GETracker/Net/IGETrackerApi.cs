using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.GETracker
{
    [Header("User-Agent", "NRuneScape (https://github.com/AntiTcb/NRuneScape)")]
    [Header("Accept", "application/x.getracker.v" + GETrackerConfig.ApiVersion + "+json")]
    internal interface IGETrackerApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        // Items
        [Get("items")]
        Task<Item[]> GetItemsAsync();
        [Get("items/{itemId}")]
        Task<Item> GetItemAsync([Path] int itemId);
        [Get("items/multi/{itemIds}")]
        Task<Item[]> GetItemsAsync([Query] int[] itemIds);
        [Get("items/ids")]
        Task<Item[]> GetItemIdsAsync();
        [Get("items/names")]
        Task<Item[]> GetItemNamesAsync();
        [Get("items/search/{name}")]
        Task<Item[]> SearchItemsAsync([Path] string name);

        // Flip Finder
        // - Favourite Items
        [Get("favourite-items")]
        Task<Item[]> GetFavouriteItems();
        [Post("favourite-items")]
        Task AddFavouriteItemAsync([Body] int itemId);
        [Delete("favourite-items/{favouriteItemsId}")]
        Task DeleteFavouriteItemAsync([Path] int favouriteItemsId, [Body] int itemId);

        // - Suggested Items
        [Get("suggested-items")]
        Task<Item[]> GetSuggestedItemsAsync();
        [Get("suggested-items/refresh")]
        Task RefreshSuggestedItemsAsync();

        // - Highest Margins
        [Get("highest-margins")]
        Task<Item[]> GetHighestMarginsAsync();

        // - GE Limits
        [Get("ge-limits")]
        Task<Item[]> GetGeLimitsAsync();

        // - New Items
        [Get("new-items")]
        Task<Item[]> GetNewItemsAsync();

        // Money Making
        // - Crafting & Smithing
        //[Get("barrows-repair")]
        //Task<BarrowsRepairData[]> GetBarrowsRepairAsync();
        [Get("blast-furnace")]
        Task<BlastFurnaceData[]> GetBlastFurnaceAsync();
        [Get("tan-leather")]
        Task<TanLeatherData[]> GetTanLeatherAsync();


        // - Herblore Profit
        [Get("herblore/clean-herbs")]
        Task<CleanHerbData[]> GetCleanHerbsAsync();
        [Get("herblore/make-potions")]
        Task<MakePotionData[]> GetMakePotionsAsync();
        [Get("herblore/unfinished-potions")]
        Task<UnfinishedPotionData[]> GetUnfinishedPotionsAsync();
        [Get("herblore/decant-potions")]
        Task<DecantPotionData[]> GetDecantPotionsAsync();

        // - Magic
        [Get("high-alchemy")]
        Task<Item[]> GetHighAlchemyItemsAsync();
        [Get("magic-tablets")]
        Task<MagicTabletData[]> GetMagicTabletsAsync();
        [Get("plank-making")]
        Task<PlankMakingData[]> GetPlankMakingAsync();
        [Get("tree-sapling")]
        Task<TreeSaplingData[]> GetTreeSaplingsAsync();

        // - Store Profit
        [Get("stores")]
        Task<Store[]> GetStoresAsync();
        [Get("stores/profit")]
        Task<Item[]> GetStoreProfitAsync();

        // Profit Tracker
        [Post("profit-tracker")]
        Task CreateTransactionAsync([Body] CreateTransactionParams args);
        [Get("profit-tracker/{id}")]
        Task<object> GetTransactionAsync();
        [Post("profit-tracker/{id}")]
        Task UpdateTransactionAsync([Path] string id, [Body] UpdateTransactionParams args);
        [Delete("profit-tracker/{id}")]
        Task DeleteTransactionAsync([Path] string id);
    }
}
