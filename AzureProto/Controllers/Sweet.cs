using Newtonsoft.Json;

namespace AzureProto.Controllers
{
    public class Sweet
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("level")]
        public string Level { get; internal set; }
    }
}