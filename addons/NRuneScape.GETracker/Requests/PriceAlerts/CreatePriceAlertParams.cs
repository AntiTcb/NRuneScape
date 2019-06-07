using System;
using System.Collections.Generic;
using System.Text;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class CreatePriceAlertParams
    {
        [ModelProperty("itemId")]
        public int ItemId { get; set; }
        [ModelProperty("field")]
        public PriceAlertField Field { get; set; }
        [ModelProperty("type")]
        public PriceAlertType Type { get; set; }
        [ModelProperty("methods")]
        public PriceAlertMethods Methods { get; set; }
        [ModelProperty("price")]
        public int Price { get; set; }
    }
}
