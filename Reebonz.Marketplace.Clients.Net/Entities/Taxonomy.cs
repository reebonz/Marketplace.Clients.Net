﻿using System.Collections.Generic;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class CategoryJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryJson> Children { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, Parent: {ParentId}";
        }
    }

    public class CategoryAttribute
    {
        public string AttributeName { get; set; }
        public string AttributeId { get; set; }
        public bool MakesVariant { get; set; }
        public bool IsRequired { get; set; }
        public bool IsFreeText { get; set; }
        public int? MaxValuesAllowedOnProduct { get; set; }
    }
    public class AttributeGroupForCategoryJson : CategoryAttribute
    {
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

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }

    public class AttributeDefinitionJson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AttributeItemJson> AttributeItems { get; set; }
        public int? MaxValuesAllowedOnProduct { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }

    public class PostAttributeJson
    {
        public string Name { get; set; }
        public bool? IsAvailable { get; set; }
        public AtributeType Type { get; set; }
    }
    public class PostAttributeResponse
    {
        public int AttributeItemId { get; set; }
        public string Name { get; set; }
        public AtributeType Type { get; set; }
    }

    public enum AtributeType
    {
        Designer,
        Size,
        Condition,
        Color,
        Gender
    }

    public class PostSwapAttributeRequest
    {
        /// <summary>
        /// Attribute Definition Id. e.g. Designer, etc.
        /// </summary>
        public string DefinitionId { get; set; }
        public int SourceAttributeId { get; set; }
        public List<int> DestinationAttributeIds { get; set; }
    }

    public class PostSwapAttributeResponse
    {

    }

}
