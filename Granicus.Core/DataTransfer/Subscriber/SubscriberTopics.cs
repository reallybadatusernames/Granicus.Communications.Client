using System.Collections.Generic;
using System.Xml.Serialization;

namespace Granicus.Core.DataTransfer.Subscriber
{
    [XmlRoot("subscriber")]
    public class SubscriberTopicsDTO
    {
        [XmlElement("send-notifications")]
        public bool SendNotification { get; set; } = false;

        [XmlElement(ElementName = "topics")]
        public SubscriberTopics Topics;
    }

    [XmlRoot(ElementName = "topic")]
    public class SubscriberTopic
    {
        [XmlElement(ElementName = "code")]
        public string Code;
    }

    [XmlRoot(ElementName = "topics")]
    public class SubscriberTopics
    {
        [XmlElement(ElementName = "topic")]
        public List<SubscriberTopic> topic;

        [XmlAttribute]
        public string type { get; set; } = "array";
    }
}
