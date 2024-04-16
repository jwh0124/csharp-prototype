using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Enums
{
    public enum CardType
    {
        [Description("UNKNOWN")]
        UNKNOWN = 0,

        [Description("CSN")]
        CSN = 1,

        [Description("SECURE")]
        SECURE = 2,

        [Description("ACCESS")]
        ACCESS = 3,

        [Description("CSN MOBILE")]
        CSN_MOBILE = 4,

        [Description("WIEGAND MOBILE")]
        WIEGAND_MOBILE = 5,

        [Description("QR")]
        QR = 6,

        [Description("SECURE QR")]
        SECURE_QR = 7,

        [Description("WIEGAND")]
        WIEGAND = 10,

        [Description("CONFIG CARD")]
        CONFIG_CARD = 11,

        [Description("CUSTOM SMART")]
        CUSTOM_SMART = 13
    }
}
