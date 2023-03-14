using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Granicus.Infrastructure.Entities
{
    public class Sms
    {
        public static Sms Create()
        {
            return new Sms();
        }

        [JsonProperty("body")]
        public string Body { get; set; } = string.Empty;

        [JsonProperty("recipients")]
        public List<Recipient> Recipients { get; set; } = new List<Recipient>();

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("status")]
        public SmsStatus status { get; set; } 
    }

    public enum SmsStatus
    {
        New,
        Queued,
        Sending,
        Completed
    }
}
