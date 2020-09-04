using Newtonsoft.Json;

namespace Granicus.Core.Entities
{
    public class Recipient
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
