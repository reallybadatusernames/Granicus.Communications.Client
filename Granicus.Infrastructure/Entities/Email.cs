using System.Collections.Generic;

using Newtonsoft.Json;

namespace Granicus.Infrastructure.Entities
{
    public class Email
    {
        public static Email Create()
        {
            return new Email();
        }

        [JsonProperty("subject")]
        public string Subject { get; set; } = string.Empty;

        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;

        [JsonProperty("recipients")]
        public List<Recipient> Recipients { get; set; } = new List<Recipient>();

        [JsonProperty("from_name")]
        public string FromName { get; set; } = string.Empty;

        [JsonProperty("from_email")]
        public string FromEmail { get; set; } = string.Empty;

        [JsonProperty("open_tracking_enabled")]
        public bool OpenTrackingEnabled { get; set; }

        [JsonProperty("click_tracking_enabled")]
        public bool ClickTrackingEnabled { get; set; }

        [JsonProperty("message_type_code")]
        public string MessageTypeCode { get; set; } = string.Empty;

        [JsonProperty("macros")]
        public Macros Macros { get; set; } = new Macros();

        [JsonProperty("_links")]
        public List<KeyValuePair<string, string>> Links { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
