using System.Xml.Serialization;

using Granicus.Core.Entities;

namespace Granicus.Core.DataTransfer
{
    [XmlRoot("subscriber")]
    public class SubscriberCreatedDTO
    {
        [XmlElement("to-param")]
        public string ToParam { get; set; }

        [XmlElement("link")]
        public string SubscriberLink { get; set; }

        [XmlElement("subscriber-uri")]
        public string SubscriberUri { get; set; }
    }
}
