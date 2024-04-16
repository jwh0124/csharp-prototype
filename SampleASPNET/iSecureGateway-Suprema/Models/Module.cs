using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Commons.Enums;

namespace iSecureGateway_Suprema.Models
{
    [Table("Module")]
    public class Module : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        
        public uint DeviceId { get; set; }

        public string? Name { get; set; }

        public bool Used { get; set; }

        public ProductType ProductType { get; set; }

        public DeviceConnectStatus ConnectStatus { get; set; }
    }
}
