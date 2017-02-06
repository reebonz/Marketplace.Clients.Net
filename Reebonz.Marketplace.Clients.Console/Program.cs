using System;
using System.Linq;
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
                : "https://uat-merchant-api.reebonz-dev.com";
            var client = new MarketplaceClient(localUrl);

            //client.Authenticate("nick.champion+m@reebonz.com", "reebonz-merchant");
            client.Authenticate("merchant-hamee@reebonz.com", "ReeB0nz1nt3gr4ti0ns002");

            //TestOrderApi(client);
            TestProductApi(client);

            System.Console.WriteLine("DONE");
        }

        private static void TestOrderApi(MarketplaceClient client)
        {
            var orders = client.Orders.GetOrdersPage(new MerchantOrdersRequest
            {
                StartDate = DateTimeOffset.Now.AddYears(-1),
                EndDate = null,
                PageNumber = 1,
                PageSize = 100,
                Status = new OrderItemStatus[0]
            });
        }

        private static void TestProductApi(MarketplaceClient client)
        {
            //var product = client.Products.Get("1279736");
            //product.Id = string.Empty;
            //var variant = product.Variants.First();
            //variant.MerchantProductCode = "12345";
            //var postResponse = client.Products.Post(product);

            var pageAndSortJsonRequest = new PageAndSortJsonRequest { PageNumber = 1, PageSize = 50 };
            var products = client.Products.Query(pageAndSortJsonRequest, null);

            var i = 1;
        }
    }
}