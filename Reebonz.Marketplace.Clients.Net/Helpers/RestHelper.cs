using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.Helpers
{
    public static class RestHelper
    {
        public const string DateTimeOffsetFormat = "yyyy/MM/dd hh:mm:ss";

        public static RestClient CreateClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);

            // Override with Newtonsoft JSON Handler
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
            client.Timeout = 90000; //90 seconds
            return client;
        }
    }
}
