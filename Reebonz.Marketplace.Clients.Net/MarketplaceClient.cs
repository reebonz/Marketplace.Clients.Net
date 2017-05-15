using System.Security.Authentication;
using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.ServiceConsumers;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net
{
    public interface IMarketplaceClient
    {
        InventoryApiConsumer Inventory { get; }
        TaxonomyApiConsumer Taxonomy { get; }
        ProductApiConsumer Products { get; }
        OrderApiConsumer Orders { get; }
        CacheApiConsumer Cache { get; }
        ApiToken Authenticate(string username, string password);
        void Authenticate(string token);
    }

    public class MarketplaceClient : IMarketplaceClient
    {
        private bool _authenticated;
        private readonly RestClient _client;
        private readonly InventoryApiConsumer _inventory;
        private readonly TaxonomyApiConsumer _taxonomy;
        private readonly ProductApiConsumer _products;
        private readonly OrderApiConsumer _orders;
        private readonly CacheApiConsumer _cache;

        public MarketplaceClient(string baseUrl, bool throwOnErrorStatus = false)
        {
            _authenticated = false;
            _client = RestHelper.CreateClient(baseUrl);
            _inventory = new InventoryApiConsumer(_client, throwOnErrorStatus);
            _taxonomy = new TaxonomyApiConsumer(_client, throwOnErrorStatus);
            _products = new ProductApiConsumer(_client, throwOnErrorStatus);
            _orders = new OrderApiConsumer(_client, throwOnErrorStatus);
            _cache = new CacheApiConsumer(_client, throwOnErrorStatus);
        }

        public InventoryApiConsumer Inventory
        {
            get
            {
                if (!_authenticated)
                    throw new AuthenticationException("Please authenticate before attempting to use the API");

                return _inventory;
            }
        }

        public TaxonomyApiConsumer Taxonomy
        {
            get
            {
                if (!_authenticated)
                    throw new AuthenticationException("Please authenticate before attempting to use the API");

                return _taxonomy;
            }
        }

        public ProductApiConsumer Products
        {
            get
            {
                if (!_authenticated)
                    throw new AuthenticationException("Please authenticate before attempting to use the API");

                return _products;
            }
        }

        public OrderApiConsumer Orders
        {
            get
            {
                if (!_authenticated)
                    throw new AuthenticationException("Please authenticate before attempting to use the API");

                return _orders;
            }
        }
        public CacheApiConsumer Cache
        {
            get
            {
                if (!_authenticated)
                    throw new AuthenticationException("Please authenticate before attempting to use the API");

                return _cache;
            }
        }

        public ApiToken Authenticate(string username, string password)
        {
            var request = new RestRequest("api/token", Method.POST);

            request.SetJsonBody(new TokenRequest
            {
                password = password,
                grant_type = "password",
                username = username
            });

            var response = _client.Execute<ApiToken>(request);

            SetAuthHeader(response.Data.access_token);
            _authenticated = true;
            return response.Data;
        }

        public void Authenticate(string token)
        {
            SetAuthHeader(token);
            _authenticated = true;
        }

        private void SetAuthHeader(string token)
        {
            _client.RemoveDefaultParameter("Authorization");
            _client.AddDefaultHeader("Authorization", "Bearer {0}".FormatWith(token));
        }
    }
}
