using System.Xml.Serialization;

namespace Granicus.Core.Entities
{
    public class QsPage
    {
        [XmlElement("code")]
        public string Code { get; set; }
    }
}
