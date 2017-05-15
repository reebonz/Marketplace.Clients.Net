using System;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public enum CacheNamespace
    {
        General,
        Taxonomy,
        Catalogue,
        Cms,
        Merchants,
        Users,
        Roles,
        Events,
        Translations,
        External
    }
    public class CacheSummary
    {
        public string Name { get; set; }
        public string MachineName { get; set; }
        public long Count { get; set; }
        public long CacheMemoryLimit { get; set; }
        public long PhysicalMemoryLimit { get; set; }
        public TimeSpan PollingInterval { get; set; }
        public string[] Keys { get; set; }
    }

    public class CacheInvalidationMessage
    {
        public string SourceMachineName { get; set; }
        public CacheNamespace? Namespace { get; set; }
        public string Prefix { get; set; }
        public string Key { get; set; }
        public string[] Keys { get; set; }
        public bool ClearOutputCache { get; set; }

        public CacheInvalidationMessage()
        {
            Keys = new string[0];
        }
    }
}
