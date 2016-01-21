using System.Collections.Generic;
using System.Net.Http;
using Reebonz.Marketplace.Clients.Net.Helpers;
using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class TaxonomyApiConsumer : BaseApiConsumer
    {
        public override string ApiControllerUrl { get; set;}

        public TaxonomyApiConsumer(string token) : base(token)
        {
            ApiControllerUrl = "api/taxonomy";
        }

        public IEnumerable<CategoryJson> GetCategories()
        {
            var url = "{ApiControllerUrl}/categories";
            return RestApiHelper.InvokeApi<IEnumerable<CategoryJson>>(url, HttpMethod.Get, ApiHeader);
        }

        public CategoryJson GetCategory(int id)
        {
            var url = "{ApiControllerUrl}/categories/{id}";
            return RestApiHelper.InvokeApi<CategoryJson>(url, HttpMethod.Get, ApiHeader);
        }

        public IEnumerable<AttributeGroupForCategoryJson> GetCategoryAttributes(int id)
        {
            var url = "{ApiControllerUrl}/categories/{id}/attributes";
            return RestApiHelper.InvokeApi<IEnumerable<AttributeGroupForCategoryJson>>(url, HttpMethod.Get, ApiHeader);
        }

        public IEnumerable<AttributeDefinitionJson> GetAttributes()
        {
            var url = "{ApiControllerUrl}/attributes";
            return RestApiHelper.InvokeApi<IEnumerable<AttributeDefinitionJson>>(url, HttpMethod.Get, ApiHeader);
        }

        public AttributeDefinitionJson GetAttribute(string id)
        {
            var url = "{ApiControllerUrl}/attributes/{id}";
            return RestApiHelper.InvokeApi<AttributeDefinitionJson>(url, HttpMethod.Get, ApiHeader);
        }

        public IEnumerable<ShippingCountryJson> GetShippingCountries()
        {
            var url = "{ApiControllerUrl}/shippingcountries";
            return RestApiHelper.InvokeApi<IEnumerable<ShippingCountryJson>>(url, HttpMethod.Get, ApiHeader);
        }
    }
}
