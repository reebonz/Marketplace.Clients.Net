using System.Collections.Generic;
using System.Net.Http;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class AuthenticationApiConsumer : BaseApiConsumer
    {
        public override string ApiControllerUrl { get; }
        public AuthenticationApiConsumer() : base(string.Empty)
        {
            ApiControllerUrl = "api/token";
        }

        public ApiToken GetApiToken(string username, string password)
        {
            var url = ApiControllerUrl;
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            };

            return RestApiHelper.InvokeApi<ApiToken>(url, HttpMethod.Post, body: data);
        }


    }
}