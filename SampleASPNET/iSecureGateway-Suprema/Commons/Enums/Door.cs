using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Enums
{
    public enum DoorStatusMode
    {
        [Description("Close")]
        CLOSE = 0,

        [Description("Open")]
        OPEN = 1
    }

    public enum DoorAlarmMode
    {
        [Description("Forced Open")]
        FORCED_OPEN = 0,

        [Description("Held Open")]
        HELD_OPEN = 1
    }

    public enum DoorScheduleMode
    {
        [Description("Operation")]
        OPERATION = 0,

        [Description("Open")]
        OPEN = 1,

        [Description("Lock")]
        LOCK = 2
    }

    public enum DoorOperationMode
    {
        [Description("Normal")]
        NORMAL = 0,

        [Description("Open")]
        OPEN = 1,

        [Description("Lock")]
        LOCK = 2
    }

    public enum DoorFireMode
    {
        [Description("Operation")]
        OPERATION = 0,

        [Description("Open")]
        OPEN = 1
    }
}
