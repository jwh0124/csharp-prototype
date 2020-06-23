using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using System;
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

            await test();
        }

        public static async Task test()
        {
            client.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(e => MqttClient_ApplicationMessageReceived(e)));
            await client.SubscribeAsync("api/test", MqttQualityOfServiceLevel.AtLeastOnce);

            while (true)
            {
                string readKey = Console.ReadLine();
                if (readKey.StartsWith("q")){
                    return;
                }
            }
        }

        private static void MqttClient_ApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            Console.Write(">>> Receive Message : ");
            Console.WriteLine(e.ApplicationMessage.ConvertPayloadToString());
            client.PublishAsync("api/test/response", e.ApplicationMessage.ConvertPayloadToString());
        }
    }
}
