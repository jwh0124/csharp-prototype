using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("ReaderStatus")]
    public class ReaderStatus : BaseEntity
    {
        [Key]
        public string ReaderCode { get; set; }

        // 0 - Close, 1 - Open
        public int MonitorStatus { get; set; }

        // 0 - Close, 1 - Open
        public int RexStatus { get; set; }

        // 0 - Normal, 1 - SOpen, 2 - Lock
        public int OperationModeStatus { get; set; }            

        // 0 - Operation, 1 - SOpen, 2 - Lock
        public int ScheduleModeStatus { get; set; }

        // 0 - Off, 1 - On
        public int HeldAlarmStatus { get; set; }

        // 0 - Off, 1 - On
        public int ForcedAlarmStatus { get; set; }

        public bool OpenedByFireDoorGroup { get; set; }

        public DeviceConnectStatus ConnectStatus { get; set; }

        public Reader Reader { get; set; } = null!;
    }
}
