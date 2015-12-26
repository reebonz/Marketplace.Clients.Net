namespace Reebonz.Marketplace.Clients.Net.Models
{
    public class Inventory : InventoryUpdate
    {
        /// <summary>
        /// Merchants unique code which identifies this SKU
        /// </summary>
        public string MerchantProductCode { get; set; }
    }

    public class InventoryUpdate
    {
        /// <summary>
        /// Quantity available for the requested SKU
        /// </summary>
        public int? QuantityAvailable { get; set; }
        /// <summary>
        /// Current list price for the product / variant
        /// </summary>
        public decimal? Price { get; set; }
    }
}
