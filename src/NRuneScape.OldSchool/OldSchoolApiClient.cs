using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NRuneScape.Entities;
using NRuneScape.OldSchool.Net;
using RestEase;

namespace NRuneScape.OldSchool
{
    public class OldSchoolApiClient
    {
        private readonly IRuneScapeApiClient _api;
        private readonly OldSchoolJsonSerializer _jsonSerializer;

        public static string Version { get; } =
            typeof(OldSchoolApiClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(OldSchoolApiClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        public OldSchoolApiClient(OldSchoolJsonSerializer serializer = null)
        {
            _jsonSerializer = serializer ?? new OldSchoolJsonSerializer();

            var httpClient = new HttpClient { BaseAddress = new Uri("https://secure.runescape.com/") };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"NRuneScape (https://github.com/AntiTcb/NRuneScape, v{Version})");

            _api = RestClient.For<IRuneScapeApiClient>(new OldSchoolRequster(httpClient, _jsonSerializer));
            _api.GERoute = "itemdb_oldschool";
        }

        public Task<CategoryInfo> GetCategoryInfoAsync()
        {
            return _api.GetCategoryInfoAsync();
        }

        public Task<Item> GetItemAsync([Query("item")] int itemId)
        {
            return _api.GetItemAsync(itemId);
        }

        public Task<Item[]> GetItemsAsync([QueryMap] GetItemsParams args)
        {
            return _api.GetItemsAsync(args);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
