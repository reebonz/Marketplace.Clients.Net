using System;
using System.Linq;
using Reebonz.Marketplace.Clients.Net.Entities;
using Reebonz.Marketplace.Clients.Net.ServiceConsumers;

namespace Reebonz.Marketplace.Clients.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var authenticationService = new AuthenticationApiConsumer();
            //var token = authenticationService.GetApiToken("camping89.merchant@gmail.com", "123456").Token;

            //System.Console.WriteLine(token);

            //try
            //{
            //    //DemoTaxonomyApi(token);
            //    //DemoProductApi(token);
            //    //DemoInventoryApi(token);
            //    DemoOrderApi(token);
            //}
            //catch (AggregateException aggregateException)
            //{
            //    var exceptionMessages = aggregateException.Flatten().InnerExceptions.Select(e => e.Message);
            //    System.Console.WriteLine("Error: {string.Join(Environment.NewLine, exceptionMessages)}");
            //}
        }

        //public static void DemoTaxonomyApi(string token)
        //{
        //    var taxonomyApiConsumer = new TaxonomyApiConsumer(token);

        //    var categories = taxonomyApiConsumer.GetCategories().ToList();

        //    var category = taxonomyApiConsumer.GetCategory(categories.First().Id);

        //    var categoryAttributes = taxonomyApiConsumer.GetCategoryAttributes(category.Id).ToList();

        //    var categoryAttribute = taxonomyApiConsumer.GetAttribute(categoryAttributes.First().AttributeId);

        //    var attributes = taxonomyApiConsumer.GetAttributes().ToList();

        //    var shippingCountries = taxonomyApiConsumer.GetShippingCountries().ToList();
        //}

        //public static void DemoProductApi(string token)
        //{
        //    var productApiConsumer = new ProductApiConsumer(token);

        //    var productPage = productApiConsumer.Get(
        //        new PagingRequest
        //        {
        //            PageNumber = 1,
        //            PageSize = 5
        //        },
        //        new FilterMerchantProductsForm
        //        {
        //            Filter = MerchantProductFilter.InStock,
        //            Status = ProductStatus.Live
        //        }
        //        );

        //    var productId = productPage.Products.First().Id;
        //    //var notOwnProduct = productApiConsumer.Get("11");
        //    var product = productApiConsumer.Get(productId);

        //    //product.Title += " - Another variant";
        //    //var createProductResponse = productApiConsumer.CreateSimpleVariant(product);
        //    //var createdProduct = createProductResponse.Resource;

        //    product.Title += " - Updated";
        //    var updateProductResponse = productApiConsumer.Update(product.Id, product);
        //    var updatedProduct = updateProductResponse.Resource;
        //}

        //public static void DemoInventoryApi(string token)
        //{
        //    var inventoryApiConsumer = new InventoryApiConsumer(token);
        //    var productApiConsumer = new ProductApiConsumer(token);

        //    var productPage = productApiConsumer.Get(new PagingRequest
        //    {
        //        PageNumber = 1,
        //        PageSize = 2
        //    }, null);

        //    var products = productPage.Products.ToList();

        //    var inventory1 = inventoryApiConsumer.Get(products.First().Variants.First().MerchantProductCode);
        //    var inventory2 = inventoryApiConsumer.Get(products.Last().Variants.First().MerchantProductCode);

        //    // bulk update inventories
        //    inventory1.QuantityAvailable += 5;
        //    inventory2.Price += 10;
        //    var postedInventory = inventoryApiConsumer.Post(new[] { inventory1, inventory2 });

        //    // inventory quantity & price update
        //    var putInventory = inventoryApiConsumer.Put(inventory1.MerchantProductCode, new InventoryUpdate
        //    {
        //        Price = inventory1.Price,
        //        QuantityAvailable = 5
        //    });

        //    // get batch job results, id comes from auditDb
        //    var batchProcessResults = inventoryApiConsumer.GetBatchJobResults("029a7eb4-e1be-4873-9702-8bfcfb96f625");
        //}

        //public static void DemoOrderApi(string token)
        //{
        //    var orderApiConsumer = new OrderApiConsumer(token);

        //    // get order page
        //    var orderPage = orderApiConsumer.Get(new PagingRequest
        //    {
        //        PageSize = 5,
        //        PageNumber = 1
        //    }, null);

        //    var orders = orderPage.Orders.ToList();

        //    // get order by id
        //    var paidOrders = orders.Where(o => o.PaymentStatus == OrderStatus.PaymentTaken).ToList();
        //    var shippedOrders = orders.Where(o => o.Shipments.Any());
        //    var order = orderApiConsumer.Get(shippedOrders.First().Id);

        //    // get shipments
        //    var shipments = orderApiConsumer.GetShipments(order.Id);
        //    var shipment = orderApiConsumer.GetShipment(order.Id, shipments.First().Id);

        //    var unshipOrders = paidOrders.Where(o => !o.Shipments.Any()).ToList();
        //    if (unshipOrders.Any())
        //    {
        //        // post shipments
        //        var unshipOrder = unshipOrders.First();
        //        var orderShipmentResponse = orderApiConsumer.PostShipment(unshipOrder.Id, new ShipOrderRequest
        //        {
        //            ItemIds = unshipOrder.Items.Select(i => i.OrderItemId).ToArray(),
        //            NumberOfPackages = 1
        //        });

        //        var orderShipment = orderShipmentResponse.Resource;
        //    }
        //}
    }
}