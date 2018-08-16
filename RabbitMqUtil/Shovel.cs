using Newtonsoft.Json;

namespace RabbitMqUtil
{
    public class Shovel
    {
        [JsonProperty("value")]
        public ShovelData ShovelData { get; set; }
    }

    public class ShovelData
    {
        [JsonProperty("src-uri")]
        public string SrcUri { get; set; }

        [JsonProperty("src-queue")]
        public string SrcQueue { get; set; }

        [JsonProperty("dest-uri")]
        public string DestUri { get; set; }

        [JsonProperty("dest-queue")]
        public string DestQueue { get; set; }

        [JsonProperty("delete-after")]
        public string DeleteAfter { get; set; }
    }
}
