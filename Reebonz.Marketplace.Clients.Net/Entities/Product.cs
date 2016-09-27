using System;
using System.Collections.Generic;
using Reebonz.Marketplace.Clients.Net.Extensions;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    /// <summary>
    /// This class contains all the optional / required fields when creating or updating a product through the API
    /// Split from the full product to avoid confusion for merchants as to what fields they should set
    /// </summary>
    public class BaseProduct
    {
        public BaseProduct()
        {
            Attributes = new AttributeKey[0];
            Variants = new Variant[0];
            Images = new Image[0];
            Keywords = new string[0];
        }

        /// <summary>
        /// Required: Title of the product
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Required: Product description, must not contain HTML
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Required: Id of the leaf node category this product should be created in
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Optional: Delimited path of categories i.e. Bags,Tote
        /// </summary>
        public string CategoryPath { get; set; }
        /// <summary>
        /// Required: List of attributes to associate with the product
        /// </summary>
        public AttributeKey[] Attributes { get; set; }
        /// <summary>
        /// Required: All products must have a minimum of 1 variant. The product code, quantity available and if applicable attribute by which the variant can differ (i.e. size) are set on the Variant instance
        /// </summary>
        public Variant[] Variants { get; set; }
        /// <summary>
        /// Required: Array of images for the product, can be specified as a remote URL or a Base64 encoded byte array
        /// </summary>
        public Image[] Images { get; set; }
        /// <summary>
        /// Optional: Keywords to help customer search for your products. Do not include words that are already contained in the products title or attributes as this will have no effect.
        /// </summary>
        public string[] Keywords { get; set; }
        /// <summary>
        /// Only specify this field if you are creating a product with multiple variants, this code is then used to uniquely identify the product whilest the MerchantProductCode on the variant is used to indicate on an order which variant was purchased.
        /// </summary>
        public string MerchantProductGroupCode { get; set; }
        /// <summary>
        /// If you have multiple products of the same colour you can store the common identifier for those products in this field
        /// We only support variants by size.
        /// </summary>
        public string CollectionId { get; set; }
        /// <summary>
        /// Optional: True if you want this product to be featured on the merchants home page, defaults to false
        /// </summary>
        public bool? Featured { get; set; }
        /// <summary>
        /// Optional: If specified this overrides the default merchatn negotiation configuration and indicates the percentage off the list price at which the merchant is perpared to consider offers at
        /// </summary>
        public decimal? NegotiationPercentageOff { get; set; }
        /// <summary>
        /// Optinoal: Exclude this product from negotiations
        /// </summary>
        public bool? DisallowNegotiations { get; set; }
        /// <summary>
        /// Required: Amount in merchants currency the product should be listed at.
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// Optional: If specified acts as an RRP price. This price is shown on product page with a slash through it and indicates the product has been reduced in price from the RRP
        /// </summary>
        public decimal? RetailPrice { get; set; }
        /// <summary>
        /// Support for pricing by country, dictionary key is 2 letter country ISO code
        /// </summary>
        public CountryPrice[] CountryPricing { get; set; }
        /// <summary>
        /// User Consignment / Non Consignment etc (Reebonz)
        /// </summary>
        public string ProductGroup { get; set; }
        /// <summary>
        /// In Demand, Clearance, Normal, New Arrival (Reebonz)
        /// </summary>
        public string StockClassification { get; set; }
        /// <summary>
        /// Source cost of goods (Reebonz)
        /// </summary>
        public decimal? CostOfGoods { get; set; }

        public static string GetId(string friendlyId)
        {
            if (friendlyId.IsNullOrEmpty())
                return null;

            return friendlyId.Contains("/") ? friendlyId : $"products/{friendlyId}";
        }
    }

    public class ProductPrice
    {
        public decimal? Retail { get; set; }
        public decimal Sale { get; set; }
        public decimal? Markdown { get; set; }
    }

    public class Product : BaseProduct
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public int Version { get; set; }
        public decimal AverageRating { get; set; }
        public int FavouriteCount { get; set; }
        public ProductStatus Status { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }

    public class PatchProduct : BaseProduct
    {
        public new decimal? ListPrice { get; set; }
    }

    public class Variant
    {
        /// <summary>
        /// Only specify this if this product has multiple variations i.e. is available in multiple sizes
        /// </summary>
        public AttributeKey Attribute { get; set; }
        /// <summary>
        /// Required: Unique product code / SKU for this variant
        /// </summary>
        public string MerchantProductCode { get; set; }
        /// <summary>
        /// Required: Quantity of this product you have for sale
        /// </summary>
        public int Quantity { get; set; }
    }

    public class ProductLocale
    {
        /// <summary>
        /// 2 letter ISO code for the language
        /// </summary>
        public string LanguageIsoCode { get; set; }
        /// <summary>
        /// Product description in the specified language
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product title in the specified language
        /// </summary>
        public string Title { get; set; }
    }

    public class Image
    {
        /// <summary>
        /// Not required please leave null or exclude from the request entirely
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Optional: Remote URL to the image, we will download the image and store it in our system from this URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Optional: If no URL is specified you must include the image as a Base64 encoded byte array, we will decode the string and store the image
        /// </summary>
        public string Base64Encoded { get; set; }
        /// <summary>
        /// Required: Original file name of the imaghe
        /// </summary>
        public string OriginalFilename { get; set; }
        /// <summary>
        /// Required: Order in which the product should be displayed starting from 1, image at position 1 will be displayed in search results and as the main image on the product detail page.
        /// </summary>
        public int Position { get; set; }
    }

    public class AttributeKey
    {
        /// <summary>
        /// Name of the attribute you are specifying, i.e. Color, Designer, Gender
        /// </summary>
        public string AttributeId { get; set; }
        /// <summary>
        /// Optional: Numeric id of the attribute value you want assigned for this attribute
        /// </summary>
        public int? AttributeItemId { get; set; }
        /// <summary>
        /// Required if the attribute you are specifying contains multiple groups of attribute values, use the 
        /// /api/taxonomy/categories/[CATEGORY_ID]/attributes
        /// APOI call to see the available attributes and groups for the category you are listing in
        /// </summary>
        public int? AttributeGroupId { get; set; }
        /// <summary>
        /// Optional: But must be supplied if the AttributeItemId is not supplied, this is the string representation of the attribute value, i.e. Blue, Red, White for the Color attribute
        /// </summary>
        public string AttributeValue { get; set; }
    }

    public class ProductPage
    {
        public PagingJson Paging { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

    public class MerchantProductsRequest : PageAndSortJsonRequest
    {
        public string MerchantId { get; set; }
        public string Query { get; set; }
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        public int? DesignerId { get; set; }
        public bool IncludeProducts { get; set; }
        public DateTimeOffset? CreatedAfter { get; set; }
        public DateTimeOffset? CreatedBefore { get; set; }
        public MerchantProductFilter? Filter { get; set; }
        public MerchantProductFilter[] Filters { get; set; }
        public ProductStatus? Status { get; set; }
        public ProductSort Sort { get; set; }
        public string Ids { get; set; }
        public string MerchantProductCodes { get; set; }

        public MerchantProductsRequest()
        {
            Filters = new MerchantProductFilter[0];
        }
    }


    public class CountryPrice
    {
        /// <summary>
        /// 2 letter ISO code of the country
        /// </summary>
        public string CountryIsoCode { get; set; }
        /// <summary>
        /// Original selling price of this item (RRP)
        /// </summary>
        public decimal? Retail { get; set; }
        /// <summary>
        /// Price you want to sell this item at
        /// </summary>
        public decimal Sale { get; set; }
        /// <summary>
        /// If specified will override the Sale price and become the new selling price, will also trigger a slash through on the price where displayed.
        /// </summary>
        public decimal? Markdown { get; set; }
    }
}