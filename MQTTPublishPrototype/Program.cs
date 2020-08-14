using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MQTTPublishPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await test();
        }

        public static async Task test()
        {
            var factory = new MqttFactory();
            var client = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("localhost", 1886)
                .WithCredentials("cubox", "cubox0000")
                .Build();

            await client.ConnectAsync(options);


            while (true)
            {
                var payload = new
                {
                    Face= new byte[2048],
                    UserNo= "12345"
                };

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("auth/face/request")
                    .WithPayload(string.Format("{0}",JsonConvert.SerializeObject(payload)))
                    .WithExactlyOnceQoS()
                    .Build();

                await client.PublishAsync(message);

                Console.WriteLine(">>> Topic : " + message.Topic + " Payload Value: " + message.ConvertPayloadToString());

                Thread.Sleep(300);
            }
        }
    }
}
