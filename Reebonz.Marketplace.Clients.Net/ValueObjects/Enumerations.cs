using System.ComponentModel;

namespace Reebonz.Marketplace.Clients.Net.ValueObjects
{
    public enum MerchantProductFilter
    {
        [FriendlyName(Name = "Filter: No Main Image")]
        NoMainImage,
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
        PaymentTaken,
        PaymentFailed,
        Shipped,
        CancellationRequested,
        Cancelled,
        ReturnRequested,
        Returned
    }

    public enum OrderStatus
    {
        Pending,
        PaymentPending,
        PaymentTaken,
        PaymentFailed,
        Deleted
    }

    public enum OrderEventType
    {
        Created,
        PaymentTaken,
        PaymentFailed,
        Shipped,
        CancellationRequested,
        CancellationRejected,
        CancellationApproved,
        Cancelled,
        ReturnRequested,
        ReturnApproved,
        Refunded,
    }
}
