using System.ComponentModel;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public enum MerchantProductFilter
    {
        [FriendlyName(Name = "Filter: No Main Image")]
        NoMainImage,
        [FriendlyName(Name = "Filter: With Main Image")]
        WithMainImage,
        [FriendlyName(Name = "Filter: Active Merchant")]
        ActiveMerchant,
        [FriendlyName(Name = "Filter: Featured Products")]
        FeaturedProducts,
        [FriendlyName(Name = "Filter: In Stock")]
        InStock,
        [FriendlyName(Name = "Filter: Out of Stock")]
        OutOfStock,
        [FriendlyName(Name = "Filter: New Products")]
        NewProducts,
        [FriendlyName(Name = "Filter: Pre-Owned Products")]
        PreownedProducts,
        [FriendlyName(Name = "Filter: No rejected")]
        NoRejected,
        [FriendlyName(Name = "Filter: Rejected")]
        Rejected,
        [FriendlyName(Name = "Filter: Submit For Approval")]
        SubmittedForApproval,
        [FriendlyName(Name = "Filter: Merchant For Approval")]
        MerchantForApproval,
        [FriendlyName(Name = "Filter: Manual Boost Applied")]
        Boosted
    }

    public enum ProductStatus
    {
        [Description("Draft"), FriendlyName(Name = "Draft")]
        Draft,
        [Description("Ready to Publish"), FriendlyName(Name = "Ready to Publish")]
        Pending,
        [Description("Published"), FriendlyName(Name = "Published")]
        Live,
        [Description("Deleted"), FriendlyName(Name = "Deleted")]
        Deleted
    }

    public enum ProductSort
    {
        [FriendlyName(Name = "Sort: Newest")]
        CreatedDescending,
        [FriendlyName(Name = "Sort: Oldest")]
        CreatedAscending,
        [FriendlyName(Name = "Sort: Most Favourited")]
        MostFavourited,
        [FriendlyName(Name = "Sort: Boost")]
        Boost,
        [FriendlyName(Name = "Sort: Price")]
        Price,
    }

    public enum OrderItemStatus
    {
        PaymentPending,
        PaymentAbandoned,
        PaymentTaken,
        PaymentFailed,
        PaymentPartiallyTaken, //For installment payments
        Shipped,
        Delivered,
        CancellationRequested,
        Cancelled,
        ReturnRequested,
        ReturnApproved,
        Returned,
        Fraudulent
    }

    public enum OrderStatus
    {
        Pending,
        PaymentAbandoned,
        PaymentPending,
        FraudPending,
        PaymentPartiallyTaken,
        PaymentTaken,
        PaymentFailed,
        PaymentCancelled,
        Fraudulent
    }

    public enum OrderEventType
    {
        Created,
        PaymentAbandoned,
        PaymentTaken,
        PaymentPartiallyTaken, //For installment payments
        PaymentFailed,
        Shipped,
        CancellationRequested,
        CancellationRejected,
        CancellationApproved,
        Cancelled,
        Delivered,
        ReturnRequested,
        ReturnApproved,
        ReturnReceived,
        ReturnRejected,
        ReturnCancelled,
        Refunded,
        Completed,
        ShipmentReversed,
        BuyerProtectionExtended,
        FraudDetected,
        ReopenFraudCase
    }
}
