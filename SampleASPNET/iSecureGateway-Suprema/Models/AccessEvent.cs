using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("EventAccess")]
    public class AccessEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Seq { get; set; }

        public uint? DeviceId { get; set; }

        public string? ReaderCode { get; set; }

        public string? UserCode { get; set; }

        public string? UserId { get; set; }

        public string? CardId { get; set; }

        public AccessEventType AccessEventType { get; set; }

        public ReaderDirection ReaderDirection { get; set; }

        public DateTime AccessTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
