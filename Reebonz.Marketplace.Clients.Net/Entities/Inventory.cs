using System.Collections.Generic;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class InventoryInfo : Inventory
    {
        /// <summary>
        /// Unique internal identifier for this product.
        /// </summary>
        public string ProductId { get; set; }
    }

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

    public class InventoryPage
    {
        /// <summary>
        /// Information about the current page and number of pages available
        /// </summary>
        public Pages Pages { get; set; }
        /// <summary>
        /// List of inventory for SKUs
        /// </summary>
        public IEnumerable<InventoryInfo> Inventory { get; set; }
    }

    public class BulkInventoryUpdate
    {
        /// <summary>
        /// List of SKUs whose price and or stock you want to update.
        /// </summary>
        public Inventory[] Skus { get; set; }
        /// <summary>
        /// URL to call on successful completion of the batch inventory update job.
        /// jobid=[job_id] will be added to the callback URL as a querystring parameter 
        /// to identify the job that just completed.
        /// </summary>
        public string Callback { get; set; }
    }

    public class BulkInventoryUpdateResponse
    {
        /// <summary>
        /// Id of the batch inventory update, can be used to retrive the batch update results once processed.
        /// </summary>
        public string JobId { get; set; }
    }
}
