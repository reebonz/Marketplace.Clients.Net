using System.Net.Http;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class ProductApiConsumer : BaseApiConsumer
    {
        public override string ApiControllerUrl { get; }

        public ProductApiConsumer(string token) : base(token)
        {
            ApiControllerUrl = "api/merchants/products";
        }

        public Product Get(string id)
        {
            var url = $"{ApiControllerUrl}/{id}";
            return RestApiHelper.InvokeApi<Product>(url, HttpMethod.Get, ApiHeader);
        }

        public ProductPage Get(PagingRequest paging, FilterMerchantProductsForm form)
        {
            var queryString = $"{paging.ToQueryString()}&{form.ToQueryString()}";
            var url = $"{ApiControllerUrl}?{queryString}";
            return RestApiHelper.InvokeApi<ProductPage>(url, HttpMethod.Get, ApiHeader);
        }

        public ApiResponse<Product> CreateSimpleVariant(BaseProduct product)
        {
            var url = ApiControllerUrl;
            return RestApiHelper.InvokeApi<ApiResponse<Product>>(url, HttpMethod.Post, ApiHeader, product);
        }

        public ApiResponse<Product> Update(string id, BaseProduct product)
        {
            var url = $"{ApiControllerUrl}/{id}";
            return RestApiHelper.InvokeApi<ApiResponse<Product>>(url, HttpMethod.Put, ApiHeader, product);
        }
    }
}
