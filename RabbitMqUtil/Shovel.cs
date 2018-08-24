using Newtonsoft.Json;

namespace RabbitMqUtil
{
    public class Shovel
    {
        [JsonProperty("value")]
        public ShovelData ShovelData { get; set; }
    }

    /// <summary>
    /// See documentation at: https://www.rabbitmq.com/shovel-dynamic.html 
    /// Example at: https://github.com/rabbitmq/rabbitmq-shovel-management/issues/13
    /// </summary>
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

        /// <summary>
        /// Needs to be dynamic as this can be either a string or an int
        /// </summary>
        [JsonProperty("delete-after")]
        public dynamic DeleteAfter { get; set; }
    }
}
