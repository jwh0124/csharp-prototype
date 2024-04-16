using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("Reader")]
    public class Reader : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        
        public uint DeviceId { get; set; }

        public string? Name { get; set; }

        public uint DoorId { get; set; }

        public string? DoorCode { get; set; }

        public uint DoorPort { get; set; }

        public uint ChannelDeviceId { get; set; }

        public uint RelayPort { get; set; }

        public uint DoorMonitorPort { get; set; }

        public uint RexPort { get; set; }

        public bool EnabledDoorForcedAlarm { get; set; }

        public bool EnabledDoorHeldAlarm { get; set; }

        public int GreenLEDPort { get; set; }

        public int BuzzerPort { get; set; }

        public int OpenTime { get; set; }

        public int HeldOpenTime { get; set; }

        public bool Used {  get; set; }

        public ProductType ProductType { get; set; }

        public SwitchType DoorMonitorSwitchType { get; set; }

        public ReaderCommunicationType CommunicationType { get; set; }

        public ReaderDirection Direction { get; set; }

        public ReaderStatus? ReaderStatus { get; set; }
    }
}
