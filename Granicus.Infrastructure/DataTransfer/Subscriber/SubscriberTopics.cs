using System.Collections.Generic;
using System.Xml.Serialization;

namespace Granicus.Infrastructure.DataTransfer.Subscriber
{
    [XmlRoot("subscriber")]
    public class SubscriberTopicsDTO
    {
        [XmlElement("send-notifications")] public bool SendNotification { get; set; } = false;

        [XmlElement(ElementName = "topics")] public SubscriberTopics Topics = new SubscriberTopics();
    }

    [XmlRoot(ElementName = "topic")]
    public class SubscriberTopic
    {
        [XmlElement(ElementName = "code")] public string Code { get; set; } = string.Empty;
    }

    [XmlRoot(ElementName = "topics")]
    public class SubscriberTopics
    {
        [XmlElement(ElementName = "topic")] public List<SubscriberTopic> topic = new List<SubscriberTopic>();

        [XmlAttribute] public string type { get; set; } = "array";
    }
}
