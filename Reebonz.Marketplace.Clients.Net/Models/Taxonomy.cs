using System.Collections.Generic;

namespace Reebonz.Marketplace.Clients.Net.Models
{
    public class CategoryJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryJson> Children { get; set; }
    }

    public class ShippingCountryJson
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class AttributeGroupForCategoryJson
    {
        public string AttributeName { get; set; }
        public string AttributeId { get; set; }
        public bool MakesVariant { get; set; }
        public bool IsRequired { get; set; }
        public bool IsFreeText { get; set; }
        public int? MaxValuesAllowedOnProduct { get; set; }
        public IEnumerable<AttributeGroupJson> AttributeGroups { get; set; }
    }

    public class AttributeGroupJson
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AttributeItemJson> AttributeItems { get; set; }
    }

    public class AttributeItemJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AttributeDefinitionJson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AttributeItemJson> AttributeItems { get; set; }
        public int? MaxValuesAllowedOnProduct { get; set; }
    }
}
