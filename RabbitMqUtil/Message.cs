using Newtonsoft.Json;

namespace RabbitMqUtil
{
    internal class Message
    {
        public string Payload { get; set; }

        public dynamic PayloadMessage
        {
            get
            {
                return JsonConvert.DeserializeObject(Payload);
            }
        }
    }
}