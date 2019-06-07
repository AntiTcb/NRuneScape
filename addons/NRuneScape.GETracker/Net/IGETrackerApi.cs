using System;
using System.Collections.Generic;
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
        // - Item Sets
        [Get("item-sets")]
        Task<ItemSet[]> GetItemSetsAsync();

        // Profit Tracker
        [Get("profit-tracker")]
        Task<Transaction[]> GetLogAsync();
        [Post("profit-tracker")]
        Task<string> CreateTransactionAsync([Body] CreateTransactionParams args);
        [Get("profit-tracker/{id}")]
        Task<Transaction> GetTransactionAsync();
        [Post("profit-tracker/{id}")]
        Task UpdateTransactionAsync([Path] string id, [Body] UpdateTransactionParams args);
        [Delete("profit-tracker/{id}")]
        Task DeleteTransactionAsync([Path] string id);
        [Get("profit-tracker/summary")]
        Task<TransactionSummary> GetSummaryAsync();
        [Get("profit-tracker/buying")]
        Task<Transaction[]> GetBuyingTransactionsAsync();
        [Get("profit-tracker/bought")]
        Task<Transaction[]> GetBoughtTransactionsAsync();
        [Get("profit-tracker/selling")]
        Task<Transaction[]> GetSellingTransactionsAsync();
        [Get("profit-tracker/sold")]
        Task<Transaction[]> GetSoldTransactionsAsync();
        [Get("profit-tracker/most-profitable")]
        Task<ItemProfit[]> GetMostProfitableItemsAsync();
        [Get("profit-tracker/active-transactions")]
        Task<Dictionary<string, Transaction[]>> GetActiveTransactionsAsync();
        [Get("profit-tracker/previous-transactions/{itemId}")]
        Task<TransactionHistory> GetPreviousTransactionsAsync([Path] int itemId);

        // Leaderboard
        [Get("leaderboard")]
        Task<Dictionary<string, Leaderboard>> GetLeaderboardsAsync();
        [Get("leaderboard/{slug}")]
        Task<LeaderboardEntry[]> GetLeaderboardAsync([Path] string slug, [QueryMap] PaginationParams args);

        // Market Watch
        [Get("market-watch")]
        Task<Index[]> GetMarketSummaryAsync();
        [Get("market-watch/{indexId}")]
        Task<Index> GetMarketIndexAsync([Path] int indexId);

        // Dashboard
        [Get("dashboard")]
        Task<Dashboard> GetDashboardAsync();

        // Users
        [Get("users/me")]
        Task<User> GetCurrentUserAsync();
        [Get("users/search/{name}")]
        Task<User[]> SearchUsersAsync([Path] string name, [QueryMap] SearchUsersParams args);
        [Get("users/{userId}")]
        Task<User> GetUserAsync([Path] string userId);

        // Price Alerts
        [Get("price-alerts")]
        Task<PriceAlert[]> GetPriceAlertsAsync();
        [Post("price-alerts")]
        Task CreatePriceAlertAsync([Body] CreatePriceAlertParams args);
        [Get("price-alerts/{itemId}")]
        Task<PriceAlert[]> GetPriceAlertsAsync([Path] int itemId);

        // Notifications
        [Get("notifications")]
        Task<Notification[]> GetNotificationsAsync();
        [Get("notifications/{notificationId}")]
        Task<Notification> GetNotification([Path] string notificationId);

        // No Authentication
        // - Hiscores
        [Get("hiscore/{username}")]
        Task<Hiscore> GetHiscoreAsync([Path] string username);
        // - RS Updates
        [Get("rs-updates")]
        Task<Update[]> GetUpdatesAsync();
        [Get("rs-updates/{id}")]
        Task<Update> GetUpdateAsync([Path] int id);
        // - API Uptime
        [Get("osb-uptime/status")]
        Task<ApiStatus> GetApiStatusAsync();
        [Get("osb-uptime/{count}")]
        Task<ApiHash[]> GetApiHashesAsync([Path] int count);
        // - Stats
        [Get("stats")]
        Task<Stat> GetStatsAsync();
        [Get("stats/online")]
        Task<OnlineUsers> GetOnlineUsersAsync();
    }
}
