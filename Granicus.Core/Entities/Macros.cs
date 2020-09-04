using Newtonsoft.Json;

namespace Granicus.Core.Entities
{
    public partial class Macros
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
