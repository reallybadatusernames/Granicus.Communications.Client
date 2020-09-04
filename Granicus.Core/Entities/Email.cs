using System.Collections.Generic;

using Newtonsoft.Json;

namespace Granicus.Core.Entities
{
    public class Email
    {
        public static Email Create()
        {
            return new Email();
        }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("recipients")]
        public List<Recipient> Recipients { get; set; }

        [JsonProperty("from_name")]
        public string FromName { get; set; }

        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        [JsonProperty("open_tracking_enabled")]
        public bool OpenTrackingEnabled { get; set; }

        [JsonProperty("click_tracking_enabled")]
        public bool ClickTrackingEnabled { get; set; }

        [JsonProperty("message_type_code")]
        public string MessageTypeCode { get; set; }

        [JsonProperty("macros")]
        public Macros Macros { get; set; }

        [JsonProperty("_links")]
        public List<KeyValuePair<string, string>> Links { get; set; }
    }
}
