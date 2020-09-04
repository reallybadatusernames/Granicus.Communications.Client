using System.Xml.Serialization;

using Granicus.Core.Entities;

namespace Granicus.Core.DataTransfer
{
    [XmlRoot("subscriber")]
    public class CreateSubscriberDTO
    {
        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("country-code")]
        public string CountryCode { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("send-notifications")]
        public bool SendSubscriberUpdateNotifications { get; set; }

        [XmlElement("digest-for")]
        public Digest SendBulletins { get; set; }
    }
}
