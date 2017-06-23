using System;
using System.Collections.Generic;

namespace NRuneScape
{
    public interface IItem : IUpdateable
    {
        /// <summary> Gets the Icon for this item. </summary>
        Uri Icon { get; }
        /// <summary> Gets the Large Icon for this item. </summary>
        Uri LargeIcon { get; }
        /// <summary> Gets the Id for this item. </summary>
        int Id { get; }
        ///<summary> Gets the Category for this item.</summary>
        string Category { get; }
        /// <summary> Gets the Icon for the Category for this item. </summary>
        Uri CategoryIcon { get; }
        /// <summary> Gets the Name for this item. </summary>
        string Name { get; }
        /// <summary> Gets the Description for this item. </summary>
        string Description { get; }
        /// <summary> Gets if this is a Member's only item. </summary>
        bool IsMembersItem { get; }                               

        /// Returns a collection of the Trade History for this item for the last 30, 90, or 180 days. 
        IReadOnlyDictionary<HistoryPeriod, ITradeHistory> TradeHistories { get; }
    }
}
