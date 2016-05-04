using System;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class BatchProcessResultSummary
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public string ProcessedBy { get; set; }
        public string FileProcessed { get; set; }
        public string AzureBlobProcessed { get; set; }
        public string AzureBlobResults { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public BatchProcessJob JobType { get; set; }
        public BatchProcessStatus Status { get; set; }
        public int ProcessedCount => ErrorCount + SuccessCount + WarningCount + IgnoredCount + CreatedCount + UpdatedCount;
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public int SuccessCount { get; set; }
        public int IgnoredCount { get; set; }
        public int CreatedCount { get; set; }
        public int UpdatedCount { get; set; }
        /// <summary>
        /// Only used if we only processed a small number of items, more efficient than storing in Azure
        /// For example lots of merchants just update inventory for 1 item at a time
        /// </summary>
        public string ResultsAsJson { get; set; }
    }

    public enum BatchProcessStatus
    {
        Success,
        Error,
        PartialSuccess
    }

    public enum BatchProcessJob
    {
        Inventory,
        Products
    }
}
