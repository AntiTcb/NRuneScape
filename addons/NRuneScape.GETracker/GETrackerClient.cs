using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.GETracker
{
    public class GETrackerClient : IGETrackerApi, IDisposable
    {
        private readonly IGETrackerApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public GETrackerJsonSerializer JsonSerializer { get; }

        public GETrackerClient(GETrackerJsonSerializer serializer = null)
        {
            JsonSerializer = serializer ?? new GETrackerJsonSerializer();
            var httpClient = new HttpClient { BaseAddress = new Uri(GETrackerConfig.BaseUri) };

            _api = RestClient.For<IGETrackerApi>(new GETrackerRequester(httpClient, JsonSerializer));
        }

        public void Dispose() => _api.Dispose();

        // Items
        public Task<Item[]> GetItemsAsync()			
			=> _api.GetItemsAsync();
        public Task<Item> GetItemAsync([Path] int itemId) 
			=> _api.GetItemAsync(itemId);
        public Task<Item[]> GetItemsAsync([Query] int[] itemIds) 
			=> _api.GetItemsAsync(itemIds);
        public Task<Item[]> GetItemIdsAsync() 
			=> _api.GetItemIdsAsync();
        public Task<Item[]> GetItemNamesAsync() 
			=> _api.GetItemNamesAsync();
        public Task<Item[]> SearchItemsAsync([Path] string name) 
			=> _api.SearchItemsAsync(name);

        // Flip Finder
        // - Favourite Items
        public Task<Item[]> GetFavouriteItems() 
			=> _api.GetFavouriteItems();
        public Task AddFavouriteItemAsync([Body] int itemId) 
			=> _api.AddFavouriteItemAsync(itemId);
        public Task DeleteFavouriteItemAsync([Path] int favouriteItemsId, [Body] int itemId) 
			=> _api.DeleteFavouriteItemAsync(favouriteItemsId, itemId);
        // - Suggested Items
        public Task<Item[]> GetSuggestedItemsAsync() 
			=> _api.GetSuggestedItemsAsync();
        public Task RefreshSuggestedItemsAsync() 
			=> _api.RefreshSuggestedItemsAsync();
        // - Highest Margins
        public Task<Item[]> GetHighestMarginsAsync() 
			=> _api.GetHighestMarginsAsync();
        // - GE Limits
        public Task<Item[]> GetGeLimitsAsync() 
			=> _api.GetGeLimitsAsync();
        // - New Items
        public Task<Item[]> GetNewItemsAsync() 
			=> _api.GetNewItemsAsync();

        // Money Making
        // - Crafting & Smithing
        public Task<BlastFurnaceData[]> GetBlastFurnaceAsync() 
			=> _api.GetBlastFurnaceAsync();
        public Task<TanLeatherData[]> GetTanLeatherAsync() 
			=> _api.GetTanLeatherAsync();
        // - Herblore Profit
        public Task<CleanHerbData[]> GetCleanHerbsAsync() 
			=> _api.GetCleanHerbsAsync();
        public Task<MakePotionData[]> GetMakePotionsAsync() 
			=> _api.GetMakePotionsAsync();
        public Task<UnfinishedPotionData[]> GetUnfinishedPotionsAsync() 
			=> _api.GetUnfinishedPotionsAsync();
        public Task<DecantPotionData[]> GetDecantPotionsAsync() 
			=> _api.GetDecantPotionsAsync();
        // - Magic
        public Task<Item[]> GetHighAlchemyItemsAsync() 
			=> _api.GetHighAlchemyItemsAsync();
        public Task<MagicTabletData[]> GetMagicTabletsAsync() 
			=> _api.GetMagicTabletsAsync();
        public Task<PlankMakingData[]> GetPlankMakingAsync() 
			=> _api.GetPlankMakingAsync();
        public Task<TreeSaplingData[]> GetTreeSaplingsAsync() 
			=> _api.GetTreeSaplingsAsync();
        // - Store Profit
        public Task<Store[]> GetStoresAsync() 
			=> _api.GetStoresAsync();
        public Task<Item[]> GetStoreProfitAsync() 
			=> _api.GetStoreProfitAsync();
        // - Item Sets
        public Task<ItemSet[]> GetItemSetsAsync() 
			=> _api.GetItemSetsAsync();

        // Profit Tracker
        public Task<Transaction[]> GetLogAsync() 
			=> _api.GetLogAsync();
        public Task<string> CreateTransactionAsync([Body] CreateTransactionParams args) 
			=> _api.CreateTransactionAsync(args);
        public Task<Transaction> GetTransactionAsync() 
			=> _api.GetTransactionAsync();
        public Task UpdateTransactionAsync([Path] string id, [Body] UpdateTransactionParams args) 
			=> _api.UpdateTransactionAsync(id, args);
        public Task DeleteTransactionAsync([Path] string id) 
			=> _api.DeleteTransactionAsync(id);
        public Task<TransactionSummary> GetSummaryAsync() 
			=> _api.GetSummaryAsync();
        public Task<Transaction[]> GetBuyingTransactionsAsync() 
			=> _api.GetBuyingTransactionsAsync();
        public Task<Transaction[]> GetBoughtTransactionsAsync() 
			=> _api.GetBoughtTransactionsAsync();
        public Task<Transaction[]> GetSellingTransactionsAsync() 
			=> _api.GetSellingTransactionsAsync();
        public Task<Transaction[]> GetSoldTransactionsAsync() 
			=> _api.GetSoldTransactionsAsync();
        public Task<ItemProfit[]> GetMostProfitableItemsAsync() 
			=> _api.GetMostProfitableItemsAsync();
        public Task<Dictionary<string, Transaction[]>> GetActiveTransactionsAsync() 
			=> _api.GetActiveTransactionsAsync();
        public Task<TransactionHistory> GetPreviousTransactionsAsync([Path] int itemId) 
			=> _api.GetPreviousTransactionsAsync(itemId);

        // Leaderboard
        public Task<Dictionary<string, Leaderboard>> GetLeaderboardsAsync() 
			=> _api.GetLeaderboardsAsync();
        public Task<LeaderboardEntry[]> GetLeaderboardAsync([Path] string slug, [QueryMap] PaginationParams args) 
			=> _api.GetLeaderboardAsync(slug, args);

        // Market Watch
        public Task<Index[]> GetMarketSummaryAsync() 
			=> _api.GetMarketSummaryAsync();
        public Task<Index> GetMarketIndexAsync([Path] int indexId) 
			=> _api.GetMarketIndexAsync(indexId);

        // Dashboard
        public Task<Dashboard> GetDashboardAsync() 
			=> _api.GetDashboardAsync();

        // Users
        public Task<User> GetCurrentUserAsync() 
			=> _api.GetCurrentUserAsync();
        public Task<User[]> SearchUsersAsync([Path] string name, [QueryMap] SearchUsersParams args) 
			=> _api.SearchUsersAsync(name, args);
        public Task<User> GetUserAsync([Path] string userId) 
			=> _api.GetUserAsync(userId);

        // Price Alerts
        public Task<PriceAlert[]> GetPriceAlertsAsync() 
			=> _api.GetPriceAlertsAsync();
        public Task CreatePriceAlertAsync([Body] CreatePriceAlertParams args) 
			=> _api.CreatePriceAlertAsync(args);
        public Task<PriceAlert[]> GetPriceAlertsAsync([Path] int itemId) 
			=> _api.GetPriceAlertsAsync(itemId);

        // Notifications
        public Task<Notification[]> GetNotificationsAsync() 
			=> _api.GetNotificationsAsync();
        public Task<Notification> GetNotification([Path] string notificationId) 
			=> _api.GetNotification(notificationId);

        // No Authentication
        // - Hiscores
        public Task<Hiscore> GetHiscoreAsync([Path] string username) 
			=> _api.GetHiscoreAsync(username);
        // - RS Updates
        public Task<Update[]> GetUpdatesAsync() 
			=> _api.GetUpdatesAsync();
        public Task<Update> GetUpdateAsync([Path] int id) 
			=> _api.GetUpdateAsync(id);
        // - API Uptime
        public Task<ApiStatus> GetApiStatusAsync() 
			=> _api.GetApiStatusAsync();
        public Task<ApiHash[]> GetApiHashesAsync([Path] int count) 
			=> _api.GetApiHashesAsync(count);
        // - Stats
        public Task<Stat> GetStatsAsync() 
			=> _api.GetStatsAsync();
        public Task<OnlineUsers> GetOnlineUsersAsync() 
			=> _api.GetOnlineUsersAsync();
    }
}
