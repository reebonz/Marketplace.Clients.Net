
namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class TokenRequest
    {
        /// <summary>
        /// Grant type must always be set to "password"
        /// </summary>
        public string grant_type { get; set; }
        /// <summary>
        /// Your Reebonz Marketplace merchant account email address
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// Your Reebonz Marketplace merchant account password
        /// </summary>
        public string password { get; set; }
    }

    public class TokenResponse
    {
        /// <summary>
        /// Token to use in the Authorization Header in subsequent API calls
        /// </summary>
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int? expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }
}
