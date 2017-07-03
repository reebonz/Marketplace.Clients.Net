using System;
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
        /// <summary>
        /// Current list price for the product / variant
        /// </summary>
        public decimal? RetailPrice { get; set; }
        /// <summary>
        /// A timestamp for when the inventory was updated in merchant system. Ensures we dont process the same update multiple times
        /// </summary>
        public DateTime? SyncTimestamp { get; set; }
        /// <summary>
        /// Force an update even if SyncTimestamp is unchanged
        /// </summary>
        public bool? ForceSync { get; set; }
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
        /// <summary>
        /// If we processed the updates immediately the results are contained in this field
        /// </summary>
        public InventoryUpdateResult[] Results { get; set; }
    }

    public class InventoryUpdateResult
    {
        /// <summary>
        /// Internal Reebonz product Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// Merchant's Id for the SKU we're updating
        /// </summary>
        public string MerchantProductCode { get; set; }
        /// <summary>
        /// Status of the udpate
        /// </summary>
        public InventoryUpdateStatus Status { get; set; }
    }

    public enum InventoryUpdateStatus
    {
        /// <summary>
        /// Inventory and or price was updated successfully
        /// </summary>
        Ok,
        /// <summary>
        /// Inventory and price unchanged
        /// </summary>
        Ignored,
        /// <summary>
        /// An error occured, price and inventory was not updated
        /// </summary>
        Error
    }
}
