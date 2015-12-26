using System.Collections.Generic;

namespace Reebonz.Marketplace.Clients.Net.Models
{
    public class BatchProcessResults
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public string JobType { get; set; }
        public BatchProcessSummary Summary { get; set; }
        public List<BatchProcessResult> Results { get; set; }
    }

    public class BatchProcessSummary
    {
        public int ProcessedCount
        {
            get { return ErrorCount + SuccessCount + WarningCount; }
        }

        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public int SuccessCount { get; set; }
    }

    public class BatchProcessResult
    {
        public string MerchantProductCode { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
