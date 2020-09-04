using System.Xml.Serialization;

namespace Granicus.Core.Entities
{
    public class Link
    {
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; }

        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }
}
