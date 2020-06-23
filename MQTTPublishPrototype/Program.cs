using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
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
                .WithTcpServer("localhost",1886)
                .Build();

            await client.ConnectAsync(options);

            int count = 0;

            while (true)
            {
                count++;
                var result = new Result
                {
                    UserNo = "12345",
                    UserName = "jung",
                    authResult = true,
                    count = count
                };
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("api/test")
                    .WithPayload(JsonSerializer.Serialize(result))
                    .WithExactlyOnceQoS()
                    .Build();
                
                Console.WriteLine("###Send Count : "+ count + " >>> Send Message : " + message.ConvertPayloadToString());

                await client.PublishAsync(message);

                client.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(e => MqttClient_ApplicationMessageReceived(e)));
                await client.SubscribeAsync("api/test/response", MqttQualityOfServiceLevel.AtLeastOnce);

                Thread.Sleep(500);
            }
        }
        private static void MqttClient_ApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            Console.Write(">>> Receive Message : ");
            Console.WriteLine(e.ApplicationMessage.ConvertPayloadToString());
        }
    }
}
