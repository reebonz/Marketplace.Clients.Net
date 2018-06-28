using Newtonsoft.Json;
using Reebonz.Marketplace.Clients.Net.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reebonz.Marketplace.Clients.Net.Entities
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
        public Customer Customer { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public OrderStatus PaymentStatus { get; set; }
        public string DeliveryCountry { get; set; }
        public AddressJson DeliveryAddress { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public IEnumerable<OrderEvent> Events { get; set; }
        public IEnumerable<OrderShipment> Shipments { get; set; }
        public IEnumerable<OrderReturn> ReturnRequests { get; set; }
        public Price OrderTotal { get; set; }
        public Price Commission { get; set; }
        public Price AccountCreditedBy { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ReebonzProductCode { get; set; }
        public string MerchantProductCode { get; set; }
        public string MerchantProductId { get; set; }
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
        public Price AccountCreditedBy { get; set; }
        public override string ToString()
        {
            return $"{OrderItemId}|{MerchantProductId}|{MerchantProductCode}";
        }
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
            OrderItemIds = new int[0];
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

        public static Price operator -(Price x, Price y)
        {
            //CheckSameCurrency(x, y, "-");
            return new Price
            {
                Amount = x.Amount - y.Amount,
                Currency = x.Currency ?? y.Currency
            };
        }
        private static void CheckSameCurrency(Price p1, Price p2, string operation)
        {
            //GOT SOME ISSUES TO DEAL WITH BEFORE WE DO THIS!
            //if (p1.Currency != null && p2.Currency != null && !p1.Currency.Equals(p2.Currency, StringComparison.OrdinalIgnoreCase))
            //    throw new InvalidOperationException($"Attempted to {operation} prices with different currencies: {p1.Currency} / {p2.Currency}");
        }
    }

    public class CancelOrderRequest
    {
        public string Message { get; set; }
        public int[] ItemIds { get; set; }
    }

    public class ShipOrderRequest
    {
        public int[] ItemIds { get; set; }
        public string ShipmentTrackingId { get; set; }
        public string ShipmentCarrier { get; set; }
        public int? NumberOfPackages { get; set; }
    }

    public class MerchantOrdersRequest : PageAndSortJsonRequest
    {
        public string OrderId { get; set; }
        public OrderItemStatus[] Status { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool GetByLastModified { get; set; }
    }
    public class AddressJson
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string TownOrCity { get; set; }
        public string StateOrCounty { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public string CountryIsoCode { get; set; }
        public bool IsStateValid { get; set; }
        public bool IsAddressValid => new[] { Line1, Line2, Line3 }.All(l => (l?.Length ?? 0) <= 35);

        public bool IsSameAs(AddressJson other)
        {
            return Name == other.Name
                   && Line1.IsSameAs(other.Line1)
                   && Line2.IsSameAs(other.Line2)
                   && Line3.IsSameAs(other.Line3)
                   && TownOrCity.IsSameAs(other.TownOrCity)
                   && StateOrCounty.IsSameAs(other.StateOrCounty)
                   && PostalCode.IsSameAs(other.PostalCode)
                   && CountryId == other.CountryId;
        }
    }
}
