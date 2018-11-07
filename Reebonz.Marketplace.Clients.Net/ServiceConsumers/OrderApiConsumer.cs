using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;
using System.Collections.Generic;

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

        public ApiResponse<OrderPage> GetOrdersPage(MerchantOrdersRequest form, bool usesApiResponse = false)
        {
            var url = $"api/merchants/orders?{form.ToQueryString()}";
            var request = new RestRequest(url, Method.GET);
            return HandleResponse<OrderPage>(Client.Execute<OrderPage>(request), usesApiResponse);
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