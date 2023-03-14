using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Granicus.Infrastructure.Entities
{
    public partial class EmailResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; } = string.Empty;

        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;

        [JsonProperty("click_tracking_enabled")]
        public bool ClickTrackingEnabled { get; set; }

        [JsonProperty("errors_to")]
        public string ErrorsTo { get; set; } = string.Empty;

        [JsonProperty("from_email")]
        public object FromEmail { get; set; } = string.Empty;

        [JsonProperty("from_name")]
        public object FromName { get; set; } = string.Empty;

        [JsonProperty("macros")]
        public object Macros { get; set; } = string.Empty;

        [JsonProperty("open_tracking_enabled")]
        public bool OpenTrackingEnabled { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; } = string.Empty;

        [JsonProperty("message_type_code")]
        public object MessageTypeCode { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("_links")]
        public List<KeyValuePair<string, string>> Links { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
