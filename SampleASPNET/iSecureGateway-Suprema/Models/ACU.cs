 using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("ACU")]
    public class ACU : BaseEntity
    {
        [Key]
        public string? Code { get; set; }

        public uint DeviceId { get; set; }

        public string? Name { get; set; }

        public string? IPAddress { get; set; }

        public ushort? Port { get; set; }

        public uint EventId { get; set; }

        public bool Used { get; set; }

        public string? FirmwareVersion { get; set; }

        public ProductType ProductType { get; set; }

        public DeviceConnectMode ConnectionMode { get; set; }

        public DeviceConnectStatus ConnectStatus { get; set; }
    }
}
