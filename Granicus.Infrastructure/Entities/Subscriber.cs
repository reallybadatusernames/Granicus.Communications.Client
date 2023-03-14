using System.Xml.Serialization;

namespace Granicus.Infrastructure.Entities
{
    [XmlRoot("subscriber")]
    public class Subscriber
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("email")]
        public string Email { get; set; } = string.Empty;

        [XmlElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [XmlElement("send-notifications")]
        public bool SendNotifications { get; set; }

        [XmlElement("country-code")]
        public string CountryCode { get; set; } = string.Empty;

        [XmlElement("digest-for")]
        public int DigestFor { get; set; }

        [XmlElement("link")]
        public string Link { get; set; } = string.Empty;
    }    
}
