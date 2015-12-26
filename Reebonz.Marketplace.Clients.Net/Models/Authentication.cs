using System.Collections.Generic;
using Newtonsoft.Json;

namespace Reebonz.Marketplace.Clients.Net.Models
{
    public class ApiHeader
    {
        public static string TokenType => "Bearer";
        public static string AuthorizationHeaderName => "Authorization";

        public ApiHeader(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

        public IDictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                {AuthorizationHeaderName, $"{TokenType} {Token}"}
            };

            return headers;
        }
    }

    public class ApiToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }
}
