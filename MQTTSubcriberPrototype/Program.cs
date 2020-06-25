using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQTTSubcriberPrototype
{
    class Program
    {
        static MqttFactory factory = new MqttFactory();
        static IMqttClient client = factory.CreateMqttClient();

        static async Task Main(string[] args)
        {

            var options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("localhost", 1886)
                .Build();

            await client.ConnectAsync(options);

            await client.SubscribeAsync("auth/card/response", MqttQualityOfServiceLevel.AtLeastOnce);
            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine(e.ApplicationMessage.ConvertPayloadToString());
            });

            while (true)
            {

            }
        }
    }
}
