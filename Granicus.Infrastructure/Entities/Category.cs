using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Granicus.Infrastructure.Entities
{
    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "category")]
        public List<Category> categories { get; set; } = new List<Category>();
    }

    [Serializable, XmlRoot("category")]
    public class Category
    {
        [XmlElement("allow-subscriptions")]
        public bool AllowSubscriptions { get; set; }

        [XmlElement("code")]
        public string Code { get; set; } = string.Empty;

        [XmlElement("default-open")]
        public bool DefaultOpen { get; set; }

        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;

        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        [XmlElement("short-name")]
        public string ShortName { get; set; } = string.Empty;

        [XmlElement("parent")]
        public Category Parent { get; set; } = new Category();

        [XmlElement("qs-page")]
        public QsPage QsPage { get; set; } = new QsPage();

        [XmlElement("category-uri")]
        public string CategoryUri { get; set; } = string.Empty;
    }
}
