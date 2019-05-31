using System;
using Voltaic.Serialization;

namespace NRuneScape.Entities
{
    public class Item
    {
        [ModelProperty("icon")]
        public string Icon { get; set; }
        [ModelProperty("icon_large")]
        public Uri LargeIcon { get; set; }
        [ModelProperty("id")]
        public int Id { get; set; }
        [ModelProperty("type")]
        public string Category { get; set; }
        [ModelProperty("typeIcon")]
        public Uri CategoryIcon { get; set; }
        [ModelProperty("name")]
        public string Name { get; set; }
        [ModelProperty("description")]
        public string Description { get; set; }
        [ModelProperty("members")]
        public bool IsMembersItem { get; set; }
        [ModelProperty("current")]
        public object Current { get; set; }
        [ModelProperty("today")]
        public object Today { get; set; }
    }
}
