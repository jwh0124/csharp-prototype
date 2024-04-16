using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace iSecureGateway_Suprema.Libs
{
    public class MqttConnector
    {
        private readonly ILogger<MqttConnector> logger;

        public MqttConnector(ILogger<MqttConnector> logger)
        {
            this.logger = logger;
        }

        public Task OnClientConnected(ClientConnectedEventArgs eventArgs)
        {
            logger.LogInformation("Client {id} connected.", eventArgs.ClientId);
            return Task.CompletedTask;
        }

        public Task OnClientDisConnected(ClientDisconnectedEventArgs eventArgs)
        {
            logger.LogInformation("Client {id} disconnected.",eventArgs.ClientId);
            return Task.CompletedTask;
        }

        public async Task PublishMessage(string topic, string payload, MqttQualityOfServiceLevel qosLevel)
        {
            var mqttFactory = new MqttFactory();

            var mqttClient = mqttFactory.CreateMqttClient();

            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost")
                .Build();

            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            logger.LogDebug("Publish Message >>> MQTT client is connected.");

            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(qosLevel)
                .Build();

            await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
            logger.LogInformation("Publish Message >>> Topic : {Topic}", topic);

            await mqttClient.DisconnectAsync();
        }
    }
}
