using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Granicus.Core.Entities
{
    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "category")]
        public List<Category> categories { get; set; }
    }

    [Serializable, XmlRoot("category")]
    public class Category
    {
        [XmlElement("allow-subscriptions")]
        public bool AllowSubscriptions { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }    

        [XmlElement("default-open")]
        public bool DefaultOpen { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("short-name")]
        public string ShortName { get; set; }

        [XmlElement("parent")]
        public Category Parent { get; set; }

        [XmlElement("qs-page")]
        public QsPage QsPage { get; set; }

        [XmlElement("category-uri")]
        public string CategoryUri { get; set; }
    }
}
