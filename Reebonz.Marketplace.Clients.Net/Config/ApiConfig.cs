using System.Configuration;

namespace Reebonz.Marketplace.Clients.Net.Config
{
    public static class ApiConfig
    {
        public static string HostName = ConfigurationManager.AppSettings["hostname"];
    }
}
