using System.Net.Http;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class InventoryApiConsumer : BaseApiConsumer
    {
        public override string ApiControllerUrl { get; }

        public InventoryApiConsumer(string token) : base(token)
        {
            ApiControllerUrl = "api/merchants/inventory";
        }

        public Inventory Get(string merchantProductCode)
        {
            var url = $"{ApiControllerUrl}/{merchantProductCode}";
            return RestApiHelper.InvokeApi<Inventory>(url, HttpMethod.Get, ApiHeader);
        }

        public HttpResponseMessage Post(Inventory[] inventories)
        {
            var url = ApiControllerUrl;
            return RestApiHelper.InvokeApi<HttpResponseMessage>(url, HttpMethod.Post, ApiHeader, inventories);
        }

        public HttpResponseMessage Put(string merchantProductCode, InventoryUpdate inventory)
        {
            var url = $"{ApiControllerUrl}/{merchantProductCode}";
            return RestApiHelper.InvokeApi<HttpResponseMessage>(url, HttpMethod.Put, ApiHeader, inventory);
        }

        public BatchProcessResults GetBatchJobResults(string jobId)
        {
            var url = $"{ApiControllerUrl}/results/{jobId}";
            return RestApiHelper.InvokeApi<BatchProcessResults>(url, HttpMethod.Get, ApiHeader);
        }
    }
}
