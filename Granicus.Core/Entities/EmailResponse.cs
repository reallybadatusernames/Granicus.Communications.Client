using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Granicus.Core.Entities
{
    public partial class EmailResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("click_tracking_enabled")]
        public bool ClickTrackingEnabled { get; set; }

        [JsonProperty("errors_to")]
        public string ErrorsTo { get; set; }

        [JsonProperty("from_email")]
        public object FromEmail { get; set; }

        [JsonProperty("from_name")]
        public object FromName { get; set; }

        [JsonProperty("macros")]
        public object Macros { get; set; }

        [JsonProperty("open_tracking_enabled")]
        public bool OpenTrackingEnabled { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("message_type_code")]
        public object MessageTypeCode { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_links")]
        public List<KeyValuePair<string, string>> Links { get; set; }
    }
}
