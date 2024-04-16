using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using static SupremaSDK.Libs.API;

namespace SupremaSDK
{
    public class ConnectionManager
    {
        private readonly ILogger<ConnectionManager> logger;
        
        public OnLogReceived? cbOnLogReceived;

        public nint Context { get; set; }

        public ConnectionManager(ILogger<ConnectionManager> logger)
        {
            this.logger = logger;
            Context = BS2_AllocateContext();
        }   

        public BS2ErrorCode Initialized()
        {
            logger.LogInformation("{time} : Initialized", DateTimeOffset.Now);

            return (BS2ErrorCode)BS2_Initialize(Context);
        }

        public void Disposed()
        {
            BS2_ReleaseContext(Context);

            logger.LogInformation("{time} : Disposed", DateTimeOffset.Now);
        }

        public BS2ErrorCode SetDeviceCallback(OnDeviceFound deviceFound, OnDeviceAccepted deviceAccepted,
            OnDeviceConnected deviceConnected, OnDeviceDisconnected deviceDisconnected, OnLogReceived logReceived)
        {
            cbOnLogReceived = logReceived;

            BS2ErrorCode result =
                (BS2ErrorCode)BS2_SetDeviceEventListener(Context, deviceFound, deviceAccepted, deviceConnected, deviceDisconnected);

            logger.LogInformation("SetDeviceEventListener : {result}", result);

            return result;
        }

        public BS2ErrorCode StartMonitoringLog(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_StartMonitoringLog(Context, deviceID, cbOnLogReceived);

            logger.LogInformation("{deviceID} StartMonitoringLog : {result}", deviceID, result);

            return result;
        }
    }
}
