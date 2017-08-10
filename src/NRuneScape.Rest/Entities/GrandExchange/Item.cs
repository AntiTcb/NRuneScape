using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Diagnostics;
using Model = NRuneScape.API.ItemModel;

namespace NRuneScape.Rest
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public class Item : RestEntity<RuneScapeRestClient>, IItem
    {
        public int Id { get; }
        public string Name { get; }
        public Uri Icon { get; }
        public Uri LargeIcon { get; }
        public string Category { get; }
        public Uri CategoryIcon { get; }

        public string CurrentPrice => TradeHistories[HistoryPeriod.Current].Price;
        public string Description { get; internal set; }
        public bool IsMembersItem { get; internal set; }
        public IReadOnlyDictionary<HistoryPeriod, TradeHistory> TradeHistories { get; internal set; }

        public string ImageUrl => $"{RuneScapeConfig.APIUrl}/m={EnumUtils.GetGERoute(GameSource)}/obj_big.gif?id={Id}";
        public string SpriteUrl => $"{RuneScapeConfig.APIUrl}/m={EnumUtils.GetGERoute(GameSource)}/obj_sprite.gif?id={Id}";

        internal Item(RuneScapeRestClient client, Game game, Model model) : base(client, game)
        {
            Icon = model.Icon;
            LargeIcon = model.LargeIcon;
            Id = model.Id;
            Category = model.Category;
            CategoryIcon = model.CategoryIcon;
            Name = model.Name;
            Update(model);
        }

        public async Task<ItemGraph> GetGraphAsync(RequestOptions options = null)
        {
            var graphModel = await RuneScape.ApiClient.GetItemGraphAsync(EnumUtils.GetGERoute(GameSource), Id, options ?? RequestOptions.Default);
            if (graphModel == null)
                return null;
            return new ItemGraph(RuneScape, GameSource, this, graphModel);
        }

        public async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetItemAsync(EnumUtils.GetGERoute(GameSource), Id, RequestOptions.Default);
            Update(updatedModel);
        }

        internal static Item Create(RuneScapeRestClient client, Game game, Model model) 
            => new Item(client, game, model);

        internal void Update(Model model)
        {
            Description = model.Description;
            IsMembersItem = model.IsMembersItem; 
            TradeHistories = model.TradeHistories
                .ToImmutableDictionary(k => k.Key, v => TradeHistory.Create(v.Value));
        }

        public override string ToString() => DebuggerDisplay;
        private string DebuggerDisplay => $"({Name} | {Id})";

        // IItem
        IReadOnlyDictionary<HistoryPeriod, ITradeHistory> IItem.TradeHistories 
            => TradeHistories.ToImmutableDictionary(k => k.Key, v => v.Value as ITradeHistory);
    }
}
