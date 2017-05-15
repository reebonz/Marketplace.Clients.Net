﻿using System;
using Reebonz.Marketplace.Clients.Net;
using Reebonz.Marketplace.Clients.Net.Entities;

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
            client.Authenticate("merchant-paolofiorillo@reebonz.com", "ReeB0nz1nt3gr4ti0ns002");

            //TestOrderApi(client);
            //TestProductApi(client);
            //TestTaxonomyApi(client);
            TestCache(client);

            System.Console.WriteLine("DONE");
        }

        private static void TestCache(MarketplaceClient client)
        {
            var flushSummary = client.Cache.GetFlush(new CacheInvalidationMessage
            {
                Namespace = CacheNamespace.Taxonomy,
                Key = "attributetypedefinitions/designer"
            });

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
            var product = new Product
            {
                Status = ProductStatus.Draft,
                Title = "Fancy Dinner skull detailed pumps",
                Description = "Fancy Dinner skull detailed pumps\nHeel (inches): 4,3,2 Heel (cm): 11,5",
                CategoryId = 73,
                Attributes = new AttributeKey[]
                {
                    new AttributeKey
                    {
                        AttributeId = "Color",
                        AttributeItemId = 2,
                    },
                    new AttributeKey
                    {
                        AttributeId = "Gender",
                        AttributeItemId = 2,
                    },
                    new AttributeKey
                    {
                        AttributeId = "Condition",
                        AttributeItemId = 5,
                    },
                    new AttributeKey
                    {
                        AttributeId = "Designer",
                        AttributeItemId = 533,
                    },
                },
                Variants = new Variant[]
                {
                    new Variant
                    {
                        Attribute = new AttributeKey
                        {
                            AttributeId = "ShoeSize",
                            AttributeItemId = 79
                        },
                        MerchantProductCode = "2109047090512",
                        Quantity = 1
                    }
                },
                Images = new Image[]
                {
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401.JPG",
                        Position = 1
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_1_D.JPG",
                        Position = 2
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_2_D.JPG",
                        Position = 3
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_3_D.JPG",
                        Position = 4
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_4_D.JPG",
                        Position = 5
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_5_D.JPG",
                        Position = 6
                    },
                    new Image
                    {
                        Url = "https://www.paolofiorillo.com/sync/foto/P16---FAY---NMMC132249TMNWB401_6_D.JPG",
                        Position = 7
                    }
                },
                MerchantProductGroupCode = "101316359-SW051666-02",
                Keywords = new string[] { },
                ListPrice = 214

            };
            //var product = client.Products.Get("1279736");
            //product.Id = string.Empty;
            //var variant = product.Variants.First();
            //variant.MerchantProductCode = "12345";
            var postResponse = client.Products.Post(product);

            var pageAndSortJsonRequest = new PageAndSortJsonRequest { PageNumber = 1, PageSize = 50 };
            var products = client.Products.Query(pageAndSortJsonRequest, null);

            var i = 1;
        }

        private static void TestTaxonomyApi(MarketplaceClient client)
        {
            var response = client.Taxonomy.PostAttribute(new PostAttributeJson
            {
                Name = "Vu Nguyen",
                Type = AtributeType.Designer
            });
        }
    }
}