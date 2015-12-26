using System.Collections.Generic;
using System.Net.Http;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class OrderApiConsumber : BaseApiConsumer
    {

        public override string ApiControllerUrl { get; }

        public OrderApiConsumber(string token) : base(token)
        {
            ApiControllerUrl = "api/merchants/orders";
        }

        public Order Get(string id)
        {
            var url = $"{ApiControllerUrl}/{id}";
            return RestApiHelper.InvokeApi<Order>(url, HttpMethod.Get, ApiHeader);
        }

        public OrderPage Get(PagingRequest paging, FilterMerchantOrdersForm form)
        {
            var queryString = $"{paging.ToQueryString()}&{form.ToQueryString()}";
            var url = $"{ApiControllerUrl}?{queryString}";
            return RestApiHelper.InvokeApi<OrderPage>(url, HttpMethod.Get, ApiHeader);
        }

        public OrderShipment GetShipment(string orderId, int shipmentId)
        {
            var url = $"{ApiControllerUrl}/{orderId}/shipments/{shipmentId}";
            return RestApiHelper.InvokeApi<OrderShipment>(url, HttpMethod.Get, ApiHeader);
        }

        public IEnumerable<OrderShipment> GetShipments(string orderId)
        {
            var url = $"{ApiControllerUrl}/{orderId}/shipments";
            return RestApiHelper.InvokeApi<IEnumerable<OrderShipment>>(url, HttpMethod.Get, ApiHeader);
        }

        public ApiResponse<OrderShipment> PostShipment(string orderId, ShipOrderRequest shipmentOrderRequest)
        {
            var url = $"{ApiControllerUrl}/{orderId}/shipments";
            return RestApiHelper.InvokeApi<ApiResponse<OrderShipment>>(url, HttpMethod.Post, ApiHeader, shipmentOrderRequest);
        }
    }
}
