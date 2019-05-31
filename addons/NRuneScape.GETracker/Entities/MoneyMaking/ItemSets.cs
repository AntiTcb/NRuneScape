using System;
using System.Collections.Generic;
using System.Text;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class ItemSet
    {
        [ModelProperty("cost")]
        public int Cost { get; set; }
        [ModelProperty("qty")]
        public int Quantity { get; set; }
        // TODO: Object type
        [ModelProperty("label")]
        public object Label { get; set; }
        [ModelProperty("totalPieces")]
        public int TotalPieces { get; set; }
        [ModelProperty("totalCost")]
        public int TotalCost { get; set; }
        [ModelProperty("totalProfit")]
        public int TotalProfit { get; set; }
        [ModelProperty("avgSellingQuantity")]
        public float AverageSellingQuantity { get; set; }
        [ModelProperty("ratio")]
        public float Ratio { get; set; }
        [ModelProperty("item")]
        public Item Item { get; set; }
        [ModelProperty("pieces")]
        public Dictionary<string, Item> Pieces { get; set; }
    }
}
