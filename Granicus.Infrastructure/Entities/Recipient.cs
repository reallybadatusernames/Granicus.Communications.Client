using Newtonsoft.Json;

namespace Granicus.Infrastructure.Entities
{
    public class Recipient
    {
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
    }
}
