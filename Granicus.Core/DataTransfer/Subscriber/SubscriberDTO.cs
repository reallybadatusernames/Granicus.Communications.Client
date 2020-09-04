using System.Xml.Serialization;

using Granicus.Core.Entities;

namespace Granicus.Core.DataTransfer
{
    [XmlRoot("subscriber")]
    public partial class SubscriberDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("to-param")]
        public string ToParam { get; set; }

        [XmlElement("lock-version")]
        public int LockVersion { get; set; }

        [XmlElement("link")]
        public Link[] Link { get; set; }

        [XmlElement("subscriber-uri")]
        public string SubscriberUri { get; set; }

        [XmlElement("subscriber-categories-uri")]
        public string SubscriberCategoriesUri { get; set; }

        [XmlElement("subscriber-topics-uri")]
        public string SubscriberTopicsUri { get; set; }

        [XmlElement("subscriber-questions-uri")]
        public string SubscriberQuestionsUri { get; set; }

        [XmlElement("subscriber-responses-uri")]
        public string SubscriberResponsesUri { get; set; }
    }

}
