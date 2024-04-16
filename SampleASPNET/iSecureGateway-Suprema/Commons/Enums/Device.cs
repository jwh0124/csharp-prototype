using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Enums
{
    public enum DeviceType
    {
        [Description("ACU")]
        ACU = 0,

        [Description("Module")]
        MODULE = 1,

        [Description("Reader")]
        READER = 2,

        [Description("Input")]
        INPUT = 3
    }

    public enum DeviceConnectMode
    {
        [Description("SERVER TO DEVICE")]
        SERVER_TO_DEVICE = 0,

        [Description("DEVICE TO SERVER")]
        DEVICE_TO_SERVER = 1
    }

    public enum DeviceConnectStatus
    {
        [Description("Connected")]
        CONNECTED = 0,

        [Description("Disconnected")]
        DISCONNECTED = 1
    }

    public enum TamperStatus
    {
        [Description("On")]
        ON = 0,

        [Description("Off")]
        OFF = 1
    }

    public enum ACStatus
    {
        [Description("Success")]
        SUCCESS = 0,

        [Description("Failure")]
        FAILURE = 1
    }
}
