using System.Xml.Serialization;

namespace Granicus.Infrastructure.Entities
{
    [XmlRoot(ElementName = "nil-classes")]
    public class NilClass
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; } = string.Empty;
    }
}
