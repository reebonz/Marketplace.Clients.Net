﻿using System.Net;
using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class ProductApiConsumer : BaseApiConsumer
    {
        internal ProductApiConsumer(RestClient client, bool throwOnErrorStatus) : base(client, throwOnErrorStatus)
        { }

        public Product Get(string id) 
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.GET);
            return Client.Execute<Product>(request).Data;
        }

        public bool Head(string id)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.HEAD);
            var response = Client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public ApiResponse Delete(string id)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.DELETE);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Put(string id, BaseProduct product)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.PUT);
            request.AddJsonBody(product);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Patch(string id, PatchProduct patchProduct)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.PATCH);
            request.AddJsonBody(patchProduct);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Post(BaseProduct product)
        {
            var request = new RestRequest("api/merchants/products", Method.POST);
            request.AddJsonBody(product);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ProductPage Query(PageAndSortJsonRequest paging, MerchantProductsRequest form)
        {
            var url = $"api/merchants/products?{paging.ToQueryString()}&{form.ToQueryString()}";
            var request = new RestRequest(url, Method.GET);
            var response = Client.Execute<ProductPage>(request);
            return response.Data;
        }
    }
}
