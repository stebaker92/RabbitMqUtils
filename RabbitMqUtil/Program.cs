using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMqUtil
{
    class Program
    {
        private static string userName = "";
        private static string password = "";
        
        // URL to the rabbitMQ dashboard
        private static string rabbitUrl = "";

        private static string virtualHost = "";
        private static string queue = "";

        private static WebClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SetupClient();

            //RetryErrorQueueAsync(virtualHost, queue).Wait();
            //PurgeErrorQueueAsync(virtualHost, queue).Wait();

            Console.WriteLine("Complete!");
        }

        private static void SetupClient()
        {
            // TODO use HttpClient

            client = new WebClient();

            client.Credentials = new NetworkCredential(userName, password);
        }

        private static async Task PurgeErrorQueueAsync(string virtualHost, string queueName)
        {
            client.UploadValues($"{rabbitUrl}api/queues/{virtualHost}/{queueName}/contents", "DELETE", new NameValueCollection());
        }

        private static async Task RetryErrorQueueAsync(string virtualHost, string queueName)
        {
            var stringErrorLength = ("_error").Length;
            var liveQueue = queueName.Remove(queueName.Length - stringErrorLength);
            var amqpurl = $"amqp://{userName}@/{virtualHost}";

            // Use the shovel plugin to move messages between queues
            var shovelApiUrl = $"{ rabbitUrl }api/parameters/shovel/{virtualHost}/retry{queueName}";

            var value = new ShovelData
            {
                SrcUri = amqpurl,
                SrcQueue = queueName,
                DestUri = amqpurl,
                DestQueue = liveQueue,
                DeleteAfter = "queue-length"
            };

            var jsonShovel = JsonConvert.SerializeObject(new Shovel { ShovelData = value });

            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            var response = await client.UploadStringTaskAsync(new Uri(shovelApiUrl), "PUT", jsonShovel);

            Console.WriteLine("Successful response: " + response);

        }

    }
}
