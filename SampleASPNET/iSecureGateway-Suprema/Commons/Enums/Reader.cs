using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Enums
{
    public enum ReaderCommunicationType
    {
        [Description("Wiegand")]
        WIEGAND = 0,

        [Description("RS485")]
        RS485 = 1
    }

    public enum ReaderDirection
    {
        [Description("Unknown")]
        UNKNOWN = 0,

        [Description("In")]
        IN = 1,

        [Description("Out")]
        OUT = 2
    }

    public enum SwitchType
    {
        [Description("Normal Open")]
        NormalOpen = 0,

        [Description("Normal close")]
        NormalClose = 1,
    }
}
