using Newtonsoft.Json;

namespace Granicus.Infrastructure.Entities
{
    public partial class Macros
    {
        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("company")]
        public string Company { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
