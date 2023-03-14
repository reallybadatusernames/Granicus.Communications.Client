using System.Xml.Serialization;

using Granicus.Infrastructure.Entities;

namespace Granicus.Infrastructure.DataTransfer
{
    [XmlRoot("subscriber")]
    public class SubscriberCreatedDTO
    {
        [XmlElement("to-param")]
        public string ToParam { get; set; } = string.Empty;

        [XmlElement("link")]
        public string SubscriberLink { get; set; } = string.Empty;

        [XmlElement("subscriber-uri")] public string SubscriberUri { get; set; } = string.Empty;
    }
}
