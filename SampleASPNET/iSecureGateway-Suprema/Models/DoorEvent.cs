using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("EventDoor")]
    public class DoorEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Seq { get; set; }

        public uint DeviceId { get; set; }

        public uint DoorId { get; set; }

        public DoorEventType DoorEventType { get; set; }

        public string? Operation { get; set; }

        public DateTime OccurredAt { get; set; }

    }
}
