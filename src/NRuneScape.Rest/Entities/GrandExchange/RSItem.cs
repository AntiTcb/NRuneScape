﻿using System;
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

        public async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetItemAsync(Id, EnumUtils.GetGERoute(GameSource));
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
