using System.Collections.Generic;
using Reebonz.Marketplace.Clients.Net.Entities;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public class TaxonomyApiConsumer : BaseApiConsumer
    {
        internal TaxonomyApiConsumer(RestClient client, bool throwOnErrorStatus) :
            base(client, throwOnErrorStatus)
        { }

        public IEnumerable<CategoryJson> GetCategories()
        {
            var request = new RestRequest("api/taxonomy/categories", Method.GET);
            return Client.Execute<List<CategoryJson>>(request).Data;
        }

        public CategoryJson GetCategory(int id)
        {
            var request = new RestRequest($"api/taxonomy/categories/{id}", Method.GET);
            return Client.Execute<CategoryJson>(request).Data;
        }

        public IEnumerable<AttributeGroupForCategoryJson> GetCategoryAttributeGroups(int id)
        {
            var request = new RestRequest($"api/taxonomy/categories/{id}/attributes", Method.GET);
            return Client.Execute<List<AttributeGroupForCategoryJson>>(request).Data;
        }

        public IEnumerable<CategoryAttribute> GetCategoryAttributes(int id)
        {
            var request = new RestRequest($"api/taxonomy/categories/{id}/attributes", Method.GET);
            return Client.Execute<List<CategoryAttribute>>(request).Data;
        }

        public IEnumerable<AttributeDefinitionJson> GetAttributes()
        {
            var request = new RestRequest($"api/taxonomy/attributes", Method.GET);
            return Client.Execute<List<AttributeDefinitionJson>>(request).Data;
        }

        public AttributeDefinitionJson GetAttribute(string id)
        {
            var request = new RestRequest($"api/taxonomy/attributes/{id}", Method.GET);
            return Client.Execute<AttributeDefinitionJson>(request).Data;
        }

        public ApiResponse<PostAttributeResponse> PostAttribute(PostAttributeJson attribute)
        {
            var request = new RestRequest("api/taxonomy/attribute", Method.POST);
            request.AddJsonBody(attribute);
            return HandleResponse<PostAttributeResponse>(Client.Execute(request), false);
        }
    }
}
