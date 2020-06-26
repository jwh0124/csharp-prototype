using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Exceptions;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                .WithCredentials("cubox", "cubox0000")
                .Build();

            client.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("Disconnected");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await client.ConnectAsync(options, CancellationToken.None);
                }
                catch
                {
                    Console.WriteLine("Reconnectioed Failed");
                }
            });

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Connection Success");
                await client.SubscribeAsync("auth/card");
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine(e.ApplicationMessage.ConvertPayloadToString());
            });

            try
            {
                await client.ConnectAsync(options, CancellationToken.None);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Connection Exception : " + ex.Message);
            }

            while (true)
            {

            }
        }
    }
}
