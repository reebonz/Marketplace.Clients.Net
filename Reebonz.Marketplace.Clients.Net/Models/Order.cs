using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reebonz.Marketplace.Clients.Net.ValueObjects;

namespace Reebonz.Marketplace.Clients.Net.Models
{
    public class OrderPage
    {
        public PagingJson Paging { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class Order
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public OrderStatus PaymentStatus { get; set; }
        public string DeliveryCountry { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public IEnumerable<OrderEvent> Events { get; set; }
        public IEnumerable<OrderShipment> Shipments { get; set; }
        public IEnumerable<OrderReturn> ReturnRequests { get; set; }

        public Price OrderTotal { get; set; }
        public Price Commission { get; set; }
        public Price AccountCreditedBy { get; set; }
    }

    public class OrderItem
    {
        public OrderItem()
        {
            AccountCreditedBy = new Price
            {
                Amount = SaleAmount.Amount - CommissionAmount.Amount,
                Currency = SaleAmount.Currency
            };

        }

        public int OrderItemId { get; set; }
        public string ReebonzProductCode { get; set; }
        public string MerchantProductCode { get; set; }
        public OrderItemStatus Status { get; set; }
        public string CancellationReason { get; set; }
        public DateTime? BuyerProtectionEndDate { get; set; }

        //Product Info
        public string Title { get; set; }
        public string Variant { get; set; }

        //Pricing Info
        public Price ListAmount { get; set; }
        public Price SaleAmount { get; set; }
        public Price DiscountAmount { get; set; }
        public Price CommissionAmount { get; set; }
        public decimal? CommissionPercentage { get; set; }
        public Price AccountCreditedBy;
    }
    public class OrderShipment
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string MerchantId { get; set; }
        public string CourierName { get; set; }
        public string CourierTrackingId { get; set; }
        public IEnumerable<OrderItemReference> Items { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTime? CollectedOn { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public string AirwayBillBase64 { get; set; }
        public string CommercialInvoiceBase64 { get; set; }
    }

    public class OrderReturn
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public IEnumerable<OrderItemReference> Items { get; set; }
        public string Reason { get; set; }
        public bool IsClosed { get; set; }
        public string TrackingNumber { get; set; }
        public DateTimeOffset? PickupBookedAt { get; set; }
    }
    public class OrderItemReference
    {
        public OrderItemReference()
        {
            Quantity = OrderItemIds.Length;
        }

        public string MerchantProductCode { get; set; }
        public string ReebonzProductCode { get; set; }
        public int[] OrderItemIds { get; set; }
        public int Quantity;
    }

    public class FilterMerchantOrdersForm
    {
        public string OrderId { get; set; }
        public OrderItemStatus[] Status { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public FilterMerchantOrdersForm()
        {
            Status = new OrderItemStatus[0];
        }
    }
    public class OrderEvent
    {
        public OrderEvent()
        {
            Timestamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Timestamp { get; set; }
        public int[] ItemIds { get; set; }
        public OrderEventType EventType { get; set; }
        public string MerchantUserId { get; set; }
        public string CustomEventType { get; set; }
    }

    public class Price
    {
        /// <summary>
        /// Usual price in currency specified.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency (3 letter code)
        /// </summary>
        public string Currency { get; set; }
    }

    public interface IShipItemsForm
    {
        int? NumberOfPackages { get; set; }
        int[] ItemIds { get; set; }
    }

    public class ShipOrderRequest : IShipItemsForm
    {
        public int[] ItemIds { get; set; }
        public string ShipmentTrackingId { get; set; }
        public string ShipmentCarrier { get; set; }
        public int? NumberOfPackages { get; set; }
    }
}
