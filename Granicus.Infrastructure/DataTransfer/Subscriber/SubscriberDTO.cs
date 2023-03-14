using System.Xml.Serialization;

using Granicus.Infrastructure.Entities;
using Newtonsoft.Json.Converters;

namespace Granicus.Infrastructure.DataTransfer
{
    [XmlRoot("subscriber")]
    public partial class SubscriberDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("email")] public string Email { get; set; } = string.Empty;

        [XmlElement("to-param")] public string ToParam { get; set; } = string.Empty;

        [XmlElement("lock-version")] public int LockVersion { get; set; }

        [XmlElement("link")] public Link[]? Link { get; set; }

        [XmlElement("subscriber-uri")] public string SubscriberUri { get; set; } = string.Empty;

        [XmlElement("subscriber-categories-uri")] public string SubscriberCategoriesUri { get; set; } = string.Empty;

        [XmlElement("subscriber-topics-uri")] public string SubscriberTopicsUri { get; set; } = string.Empty;

        [XmlElement("subscriber-questions-uri")] public string SubscriberQuestionsUri { get; set; } = string.Empty;

        [XmlElement("subscriber-responses-uri")] public string SubscriberResponsesUri { get; set; } = string.Empty;
    }

}
