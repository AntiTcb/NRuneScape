using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Model = NRuneScape.API.GraphModel;

namespace NRuneScape.Rest
{
    public class ItemGraph : RestEntity<RuneScapeRestClient>
    {
        private static DateTimeOffset _graphEpoch => DateTimeOffset.Parse("01 Jan 1970 00:00:00 GMT");

        public int ItemId { get; }

        private ConcurrentDictionary<int, (DateTimeOffset, double)> _daily;
        private ConcurrentDictionary<int, (DateTimeOffset, double)> _average;
        private Item _item;

        internal ItemGraph(RuneScapeRestClient client, Game game, Item item, Model model)
            : this(client, game, item.Id, model) => _item = item;

        internal ItemGraph(RuneScapeRestClient client, Game game, int itemId, Model model) 
            : base(client, game)
        {
            ItemId = itemId;
            _daily = new ConcurrentDictionary<int, (DateTimeOffset, double)>();
            _average = new ConcurrentDictionary<int, (DateTimeOffset, double)>();

            foreach (var time in model.Daily) {
                var day = _graphEpoch.AddMilliseconds(double.Parse(time.Key));
                _daily.AddOrUpdate((day - _graphEpoch).Days, (day, time.Value), (k,v) => v = (day, time.Value));
            }

            foreach (var time in model.Average)
            {
                var day = _graphEpoch.AddMilliseconds(double.Parse(time.Key));
                _average.AddOrUpdate((day - _graphEpoch).Days, (day, time.Value), (k,v) => v = (day, time.Value));
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
