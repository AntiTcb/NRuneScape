using System;
using System.Collections.Generic;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class Item
    {
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("itemId")]
        public int ItemId { get; set; }
        [ModelProperty("name")]
        public string Name { get; set; }
        [ModelProperty("icon")]
        public string IconUrl { get; set; }
        [ModelProperty("buyingQuantity")]
        public int BuyingQuantity { get; set; }
        [ModelProperty("sellingQuantity")]
        public int SellingQuantity { get; set; }
        [ModelProperty("buySellRatio")]
        public float BuySellRatio { get; set; }
        [ModelProperty("overall")]
        public int OverallPrice { get; set; }
        [ModelProperty("buying")]
        public int BuyingPrice { get; set; }
        [ModelProperty("selling")]
        public int SellingPrice { get; set; }
        [ModelProperty("approxProfit")]
        public int ApproximateProfit { get; set; }
        [ModelProperty("buyPriceCurrent")]
        public bool IsBuyPriceCurrent { get; set; }
        [ModelProperty("sellPriceCurrent")]
        public bool IsSellPriceCurrent { get; set; }
        [ModelProperty("lastKnownBuyTime")]
        public DateTimeOffset LastKnownBuyTime { get; set; }
        [ModelProperty("lastKnownSellTime")]
        public DateTimeOffset LastKnownSellTime { get; set; }
        [ModelProperty("buyLimit")]
        public int BuyLimit { get; set; }
        [ModelProperty("members")]
        public bool IsMembers { get; set; }
        [ModelProperty("lowAlch")]
        public int LowAlchPrice { get; set; }
        [ModelProperty("highAlch")]
        public int HighAlchPrice { get; set; }
        [ModelProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
        [ModelProperty("cachedUntil")]
        public DateTimeOffset CachedUntil { get; set; }
        [ModelProperty("slug")]
        public string Slug { get; set; }
        [ModelProperty("url")]
        public string Url { get; set; }
        [ModelProperty("favouriteItemsId")]
        public Optional<int> FavouriteItemId { get; set; }
        [ModelProperty("extraFields")]
        public Optional<Dictionary<string, object>> ExtraFields { get; set; }
    }
}
