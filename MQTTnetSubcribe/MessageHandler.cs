using MQTTnet;
using MQTTnet.Client.Receiving;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQTTSubcriberPrototype
{
    public class MessageHandler : IMqttApplicationMessageReceivedHandler
    {
        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.ApplicationMessage.ConvertPayloadToString());

            return null;
        }
    }
}
