using System.Xml.Serialization;

namespace Granicus.Infrastructure.Entities
{
    public class Link
    {
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; } = string.Empty;

        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; } = string.Empty;
    }
}
