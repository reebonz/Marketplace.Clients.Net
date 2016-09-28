using Reebonz.Marketplace.Clients.Net;

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

            System.Console.WriteLine("DONE");
        }
    }
}