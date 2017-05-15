using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class CacheApiConsumer : BaseApiConsumer
    {
        internal CacheApiConsumer(RestClient client, bool throwOnErrorStatus) :
            base(client, throwOnErrorStatus)
        { }

        public ApiResponse<CacheSummary> GetFlush(CacheInvalidationMessage message)
        {
            var queryString = message.ToQueryString();

            var request = new RestRequest($"api/cache/flush?{queryString}", Method.GET);
            return HandleResponse<CacheSummary>(Client.Execute(request), false);
        }
    }
}
