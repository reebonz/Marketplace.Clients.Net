using System.Collections.Generic;
using System.Linq;
using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using Reebonz.Marketplace.Clients.Net.Helpers;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class OrderApiConsumer : BaseApiConsumer
    {
        internal OrderApiConsumer(RestClient client, bool throwOnErrorStatus) :
            base(client, throwOnErrorStatus)
        {
        }

        public Order GetOrder(string id)
        {
            var request = new RestRequest("api/merchants/orders/" + id, Method.GET);
            return Client.Execute<Order>(request).Data;
        }

        public OrderShipment GetShipment(string id, int shipmentId)
        {
            var request = new RestRequest("api/merchants/orders/{0}/shipments/{1}".FormatWith(id, shipmentId.ToString() ?? ""), Method.GET);
            return Client.Execute<OrderShipment>(request).Data;
        }

        public IEnumerable<OrderShipment> GetShipments(string id)
        {
            var request = new RestRequest("api/merchants/orders/{0}/shipments".FormatWith(id), Method.GET);
            return Client.Execute<List<OrderShipment>>(request).Data;
        }

        public IEnumerable<Order> GetOrders(MerchantOrdersRequest form)
        {
            var response = GetOrdersPage(form);
            return response.Resource?.Orders;
        }

        public ApiResponse<OrderPage> GetOrdersPage(MerchantOrdersRequest form)
        {
            var url = "api/merchants/orders?";

            if (form != null)
            {
                url += $"PageNumber={(form.PageNumber ?? 1)}&PageSize={(form.PageSize ?? 25)}";

                if (form.StartDate.HasValue)
                    url += $"&StartDate={form.StartDate.Value.ToString(RestHelper.DateTimeOffsetFormat)}";

                if (form.EndDate.HasValue)
                    url += $"&EndDate={form.EndDate.Value.ToString(RestHelper.DateTimeOffsetFormat)}";

                if (form.Status != null && form.Status.Any()) 
                    url += $"&Status={string.Join("&Status=", form.Status)}";

                url += $"&GetByLastModified={form.GetByLastModified}";
            }

            var request = new RestRequest(url, Method.GET);
            return HandleResponse<OrderPage>(Client.Execute<OrderPage>(request), false);
        }

        public ApiResponse<OrderShipment> CreateShipment(string id, ShipOrderRequest form)
        {
            var request = new RestRequest("api/merchants/orders/{0}/shipments".FormatWith(id), Method.POST);
            request.AddJsonBody(form);
            return HandleResponse<OrderShipment>(Client.Execute(request));
        }

        public ApiResponse<Order> Cancel(string id, CancelOrderRequest form)
        {
            var request = new RestRequest("api/merchants/orders/{0}/cancel".FormatWith(id), Method.PUT);
            request.AddJsonBody(form);
            return HandleResponse<Order>(Client.Execute(request));
        }
    }
}