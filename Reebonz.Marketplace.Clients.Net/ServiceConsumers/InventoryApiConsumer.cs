using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class InventoryApiConsumer : BaseApiConsumer
    {
        internal InventoryApiConsumer(RestClient client, bool throwOnErrorStatus) : base(client, throwOnErrorStatus)
        { }

        public Inventory Get(string merchantProductCode)
        {
            var request = new RestRequest("api/merchants/inventory/" + merchantProductCode, Method.GET);
            return Client.Execute<Inventory>(request).Data;
        }

        public InventoryPage Get(int pageNumber, int pageSize, ProductStatus? status = null)
        {
            var request = new RestRequest("api/merchants/inventory?pageNumber={0}&pageSize={1}{2}".FormatWith(
                pageNumber,
                pageSize,
                status == null ? string.Empty : "&status={0}".FormatWith(status)), Method.GET);

            return Client.Execute<InventoryPage>(request).Data;
        }

        public ApiResponse<BulkInventoryUpdateResponse> Post(Inventory[] skus)
        {
            var request = new RestRequest("api/merchants/inventory", Method.POST);
            request.AddJsonBody(skus);
            return HandleResponse<BulkInventoryUpdateResponse>(Client.Execute(request), false);
        }

        public ApiResponse<Inventory> Put(string merchantProductCode, InventoryUpdate inventory)
        {
            var request = new RestRequest("api/merchants/inventory/{0}".FormatWith(merchantProductCode), Method.PUT);
            request.AddJsonBody(inventory);
            return HandleResponse<Inventory>(Client.Execute(request));
        }

        public BatchProcessResultSummary GetBatchJobResults(string jobId)
        {
            var request = new RestRequest("api/merchants/inventory/results/{0}".FormatWith(jobId), Method.GET);
            return Client.Execute<BatchProcessResultSummary>(request).Data;
        }
    }
}
