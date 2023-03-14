using System.Xml.Serialization;

namespace Granicus.Infrastructure.Entities
{
    public class QsPage
    {
        [XmlElement("code")]
        public string Code { get; set; } = string.Empty;
    }
}
