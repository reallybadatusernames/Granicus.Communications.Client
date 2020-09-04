using System.Xml.Serialization;

namespace Granicus.Core.Entities
{
    [XmlRoot(ElementName = "nil-classes")]
    public class NilClass
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
