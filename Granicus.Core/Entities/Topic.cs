using System.Xml.Serialization;
using System.Collections.Generic;

namespace Granicus.Core.Entities
{
    [XmlRoot("topics")]
    public class Topics
    {
        [XmlElement(ElementName = "topic")]
        public List<Topic> topics { get; set; }
    }

    [XmlRoot("topic")]
    public class Topic
    {
        [XmlElement("code")]
        public string Code { get; set; }

        [XmlElement("to-param")]
        public string ToParam { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("short-name")]
        public string ShortName { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("send-by-email-enabled")]
        public bool SendByEmailEnabled { get; set; }

        [XmlElement("wireles-enabled")]
        public string WirelessEnabled { get; set; }

        [XmlElement("rss-feed-url")]
        public string RssFeedUrl { get; set; }

        [XmlElement("rss-feed-title")]
        public string RssFeedTitle { get; set; }

        [XmlElement("rss-feed-description")]
        public string RssFeedDescription { get; set; }

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
        public Page[] Pages { get; set; }
    }
}
