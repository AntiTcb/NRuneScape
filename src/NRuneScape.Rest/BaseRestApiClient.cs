using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    internal abstract class BaseRestApiClient : IDisposable
    {
        public IRuneScapeRestApi API { get; }
        protected bool _isDisposed;

        internal abstract Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string route, string gameMode);

        public BaseRestApiClient() : this(new RestDeserializer()) { }
        public BaseRestApiClient(IResponseDeserializer responseDeserializer)
        {
            API = new RestClient(RuneScapeConfig.APIUrl) { ResponseDeserializer = responseDeserializer }
                .For<IRuneScapeRestApi>();
            API.UserAgent = RuneScapeConfig.UserAgent;
        }

        internal async Task<RuneDateModel> GetUpdateTimeAsync(string route)
        {
            try
            {
                API.GERoute = route;
                var resp = await API.GetUpdateTimeAsync();
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        internal async Task<ItemModel> GetItemAsync(int itemId, string route)
        {
            try
            {
                API.GERoute = route;
                var resp = await API.GetItemAsync(itemId);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        internal async Task<IReadOnlyCollection<ItemModel>> GetItemsAsync(string itemName, string route, int categoryId, GetItemParams args)
        {
            API.GERoute = route;
            var resp = await API.GetItemsAsync(itemName, args.AfterPageNum ?? 1, categoryId);
            return resp.GetContent();
        }

        public void Dispose() => Dispose(true);

        internal virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    (API as IDisposable)?.Dispose();
                }
                _isDisposed = true;
            }
        }
    }
}
