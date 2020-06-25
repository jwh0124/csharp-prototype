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
                .WithTcpServer("localhost", 1886)
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
                if (count%2 == 0)
                {
                    result.authResult = false;
                }
                else
                {
                    result.authResult = true;
                }
                
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("auth/card/request")
                    .WithPayload("62A70859")
                    .WithExactlyOnceQoS()
                    .Build();

                Console.WriteLine("###Send Count : "+ count + " >>> Send Message : " + message.ConvertPayloadToString());

                await client.PublishAsync(message);


                Thread.Sleep(500);
            }
        }
    }
}
