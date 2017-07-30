using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = NRuneScape.API.GraphModel;

namespace NRuneScape.Rest
{
    public class ItemGraph : RestEntity<RuneScapeRestClient>
    {
        private static DateTimeOffset _graphEpoch => DateTimeOffset.Parse("01 Jan 1970 00:00:00 GMT");

        public int ItemId { get; }

        private Dictionary<int, (DateTimeOffset, double)> _daily;
        private Dictionary<int, (DateTimeOffset, double)> _average;
        private Item _item;

        internal ItemGraph(RuneScapeRestClient client, Game game, int itemId, Model model) 
            : base(client, game)
        {
            ItemId = itemId;
            _daily = new Dictionary<int, (DateTimeOffset, double)>();
            _average = new Dictionary<int, (DateTimeOffset, double)>();

            foreach (var time in model.Daily) {
                var day = _graphEpoch.AddMilliseconds(double.Parse(time.Key));
                _daily.Add((day - _graphEpoch).Days, (day, time.Value));
            }

            foreach (var time in model.Average)
            {
                var day = _graphEpoch.AddMilliseconds(double.Parse(time.Key));
                _average.Add((day - _graphEpoch).Days, (day, time.Value));
            }
        }

        // TODO: CacheMode?
        public async ValueTask<Item> GetItem(bool forceDownload = false)
        {
            if (_item == null || forceDownload)
                _item = await RuneScape.GetItemAsync(ItemId, GameSource);
            return _item;
        }
    }
}
