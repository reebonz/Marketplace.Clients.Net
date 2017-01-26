using System;
using Reebonz.Marketplace.Clients.Net;
using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.ServiceConsumers;

namespace Reebonz.Marketplace.Clients.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var localUrl = true
                ? "http://dev-merchant-api.reebonz.com"
                : "https://marketplace-api-sandbox.reebonz-dev.com";
            var client = new MarketplaceClient(localUrl);

            client.Authenticate("nick.champion+m@reebonz.com", "reebonz-merchant");

            //var product = client.Products.Get("1279736");
            //product.Id = string.Empty;
            //var variant = product.Variants.First();
            //variant.MerchantProductCode = "12345";
            //var postResponse = client.Products.Post(product);

            var orders  = client.Orders.GetOrdersPage(new MerchantOrdersRequest
            {
                StartDate = DateTimeOffset.Now.AddYears(-1),
                EndDate = null,
                PageNumber = 1,
                PageSize = 100,
                Status = new OrderItemStatus[0]
            });

            System.Console.WriteLine("DONE");
        }
    }
}