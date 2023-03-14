using System.Xml.Serialization;
using System.Collections.Generic;

namespace Granicus.Infrastructure.Entities
{
    [XmlRoot("topics")]
    public class Topics
    {
        [XmlElement(ElementName = "topic")]
        public List<Topic> topics { get; set; } = new List<Topic>();
    }

    [XmlRoot("topic")]
    public class Topic
    {
        [XmlElement("code")]
        public string Code { get; set; } = string.Empty;

        [XmlElement("to-param")]
        public string ToParam { get; set; } = string.Empty;

        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        [XmlElement("short-name")]
        public string ShortName { get; set; } = string.Empty;

        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;

        [XmlElement("send-by-email-enabled")]
        public bool SendByEmailEnabled { get; set; }

        [XmlElement("wireles-enabled")]
        public string WirelessEnabled { get; set; } = string.Empty;

        [XmlElement("rss-feed-url")]
        public string RssFeedUrl { get; set; } = string.Empty;

        [XmlElement("rss-feed-title")]
        public string RssFeedTitle { get; set; } = string.Empty;

        [XmlElement("rss-feed-description")]
        public string RssFeedDescription { get; set; } = string.Empty;

        [XmlElement("pagewatch-enabled")]
        public bool PageWatchEnabled { get; set; }

        [XmlElement("pagewatch-suspended")]
        public bool PageWatchSuspended { get; set; }

        [XmlElement("default-pagewatch-results")]
        public int DefaultPageWatchResults { get; set; }

        [XmlElement("pagewatch-autosend")]
        public bool PageWatchAutoSend { get; set; }

        [XmlElement("pagewatch-type")]
        public int PageWatchType { get; set; }

        [XmlElement("watch-tagged-content")]
        public bool WatchTaggedContent { get; set; }

        [XmlElement("pages")]
        public Page[]? Pages { get; set; } 
    }
}
