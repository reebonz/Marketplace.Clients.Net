using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;
using System.Net;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class CacheApiConsumer : BaseApiConsumer
    {
        internal CacheApiConsumer(RestClient client, bool throwOnErrorStatus) :
            base(client, throwOnErrorStatus)
        { }

        public bool GetFlush(CacheInvalidationMessage message)
        {
            var queryString = message.ToQueryString();

            var request = new RestRequest($"api/cache/flush?{queryString}", Method.GET);

            var response = Client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
