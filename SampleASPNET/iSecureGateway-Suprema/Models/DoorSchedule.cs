using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("DoorSchedule")]
    public class DoorSchedule : BaseEntity
    {
        [Key]
        public string? Code { get; set; }
        
        public uint Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Reader>? Readers { get; set; }

        public virtual AccessSchedule? LockAccessSchedule { get; set; }

        public virtual AccessSchedule? UnLockAccessSchedule { get; set; }
    }
}
