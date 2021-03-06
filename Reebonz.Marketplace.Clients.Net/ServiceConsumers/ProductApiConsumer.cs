﻿using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.Extensions;
using RestSharp;
using System.Net;

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

        public ApiResponse<Product> Delete(string id)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.DELETE);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> PutUnpublish(string id)
        {
            var request = new RestRequest("api/merchants/products/{0}/unpublish".FormatWith(id), Method.PUT);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> PutDraft(string id)
        {
            var request = new RestRequest("api/merchants/products/{0}/draft".FormatWith(id), Method.PUT);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Put(string id, Product product)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.PUT);
            request.AddJsonBody(product);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Patch(string id, object patchProduct)
        {
            var request = new RestRequest("api/merchants/products/{0}".FormatWith(id), Method.PATCH);
            request.AddJsonBody(patchProduct);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ApiResponse<Product> Post(Product product)
        {
            var request = new RestRequest("api/merchants/products", Method.POST);
            request.AddJsonBody(product);
            return HandleResponse<Product>(Client.Execute(request));
        }

        public ProductPage Query(MerchantProductsRequest form)
        {
            var url = $"api/merchants/products?{form.ToQueryString()}";
            var request = new RestRequest(url, Method.GET);
            var response = Client.Execute<ProductPage>(request);
            return response.Data;
        }

        public BulkSetLiveResponse PushBulkSetLive(string merchantId)
        {
            var url = $"api/admin/catalogue/{merchantId}/setlive";
            var request = new RestRequest(url, Method.PUT);
            var response = Client.Execute<BulkSetLiveResponse>(request);
            return response.Data;
        }
    }
}
