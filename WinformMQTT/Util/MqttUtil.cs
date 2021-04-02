using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_Face_XT_Test.Util
{
    public class MqttUtil
    {
        static readonly IMqttFactory _factory = new MqttFactory();
        static readonly IMqttClient _client = _factory.CreateMqttClient();

        public bool Mqtt_Connect(string ip, int port)
        {
            var options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer(ip, port)
            .WithCredentials("cubox", "cubox0000")
            .Build();

            return _client.ConnectAsync(options).Result.ResultCode == MqttClientConnectResultCode.Success;
        }

        public void Mqtt_Pub(string Topic, string Message)
        {
            _client.PublishAsync(Topic, Message);
        }

        public async Task Mqtt_Sub(List<string> topicList)
        {
            foreach (var topic in topicList)
            {
                await _client.SubscribeAsync(topic);
            }

            _client.UseApplicationMessageReceivedHandler(e =>
            {
                
            });
        }
    }
}
