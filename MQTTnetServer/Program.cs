using MQTTnet;
using MQTTnet.Server;
using System;
using System.Threading.Tasks;

namespace MQTTServerPrototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await test();
        }

        public static async Task test()
        {
            Console.WriteLine("Hello World! for MQTTnet Server...");
            // Start a MQTT server.
            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(new MqttServerOptions());
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            await mqttServer.StopAsync();
        }
    }
}
