
using RestSharp;
using Reebonz.Marketplace.Clients.Net.Helpers;

namespace Reebonz.Marketplace.Clients.Net.Extensions
{
    public static class RestRequestExtensions
    {
        public static void SetJsonBody(this RestRequest request, object body)
        {
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddJsonBody(body);
        }
    }
}
