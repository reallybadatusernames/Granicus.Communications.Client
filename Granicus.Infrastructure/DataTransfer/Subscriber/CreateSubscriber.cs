using System.Xml.Serialization;

using Granicus.Infrastructure.Entities;

namespace Granicus.Infrastructure.DataTransfer
{
    [XmlRoot("subscriber")]
    public class CreateSubscriberDTO
    {
        [XmlElement("email")]
        public string Email { get; set; } = string.Empty;

        [XmlElement("country-code")]
        public string CountryCode { get; set; } = string.Empty;

        [XmlElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [XmlElement("send-notifications")]
        public bool SendSubscriberUpdateNotifications { get; set; }

        [XmlElement("digest-for")]
        public Digest SendBulletins { get; set; }
    }
}
