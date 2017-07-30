using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEase.Implementation;

namespace NRuneScape.API
{
    internal class RuneScapeRestApiClient : IDisposable
    {
        public event Func<string, Task> SentRequest {
            add => _sentRequestEvent.Add(value);
            remove => _sentRequestEvent.Remove(value);
        }
        internal readonly AsyncEvent<Func<string, Task>> _sentRequestEvent = new AsyncEvent<Func<string, Task>>();

        public IRuneScapeRestApi API { get; }
        protected bool _isDisposed;
        protected HttpClient _httpClient;

        protected virtual RequestModifier _defaultRequestModifier =>
            async (httpRequestMessage, ct)
                => await _sentRequestEvent.InvokeAsync(httpRequestMessage.RequestUri.ToString());

        public RuneScapeRestApiClient() : this(new RestDeserializer()) { }
        public RuneScapeRestApiClient(IResponseDeserializer responseDeserializer)
        {
            _httpClient = new HttpClient(new ModifyingClientHttpHandler(_defaultRequestModifier)) { BaseAddress = new Uri(RuneScapeConfig.APIUrl) };

            API = new RestClient(_httpClient) { ResponseDeserializer = responseDeserializer }.For<IRuneScapeRestApi>();
            API.UserAgent = RuneScapeConfig.UserAgent;
        }

        internal virtual Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string route, string gameMode, RequestOptions options)
            => throw new NotSupportedException();

        internal async Task<CategoryInfoModel[]> GetCategoryInfoAsync(string route, int categoryId, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(route, nameof(route));
            Preconditions.AtLeast(categoryId, 0, nameof(categoryId));
            Preconditions.AtMost(categoryId, 37, nameof(categoryId));

            API.GERoute = route;

            try
            {
                var resp = await API.GetCategoryInfoAsync(categoryId, options.CancelToken).ConfigureAwait(false);
                return resp.GetContent().Details;
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<ItemModel> GetItemAsync(string route, int itemId, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(route, nameof(route));
            Preconditions.AtLeast(itemId, 0, nameof(itemId));

            API.GERoute = route;

            try
            {
                var resp = await API.GetItemAsync(itemId, options.CancelToken).ConfigureAwait(false);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<ItemModel[]> GetItemsAsync(string route, string itemQuery, int categoryId, GetItemParams args, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(itemQuery, nameof(itemQuery));
            Preconditions.AtLeast(categoryId, 0, nameof(categoryId));
            Preconditions.AtMost(categoryId, 37, nameof(categoryId));
            Preconditions.AtLeast(args.AfterPageNum ?? 1, 1, nameof(args.AfterPageNum));

            API.GERoute = route;

            try
            {
                var resp = await API.GetItemsAsync(itemQuery, args.AfterPageNum ?? 1, categoryId, options.CancelToken);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<GraphModel> GetItemGraphAsync(string route, int itemId, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(route, nameof(route));
            Preconditions.AtLeast(itemId, 0, nameof(itemId));

            API.GERoute = route;

            try
            {
                var resp = await API.GetItemGraphAsync(itemId, options.CancelToken).ConfigureAwait(false);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }

        internal async Task<Stream> GetItemImageAsync(string route, int itemId, string imageSize, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(route, nameof(route));
            Preconditions.AtLeast(itemId, 0, nameof(itemId));
            Preconditions.NotNullOrWhitespace(imageSize, nameof(imageSize));

            API.GERoute = route;

            try
            {
                var resp = await API.GetItemImageAsync(imageSize, itemId, options.CancelToken).ConfigureAwait(false);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }
        internal async Task<RuneDateModel> GetUpdateTimeAsync(string route, RequestOptions options)
        {
            Preconditions.NotNullOrWhitespace(route, nameof(route));

            API.GERoute = route;

            try
            {
                var resp = await API.GetUpdateTimeAsync(options.CancelToken).ConfigureAwait(false);
                return resp.GetContent();
            }
            catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound) { return null; }
        }

        // IDisposable
        public void Dispose() => Dispose(true);
        internal virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    (API as IDisposable)?.Dispose();

                _isDisposed = true;
            }
        }
    }
}
