using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("AccessSchedule")]
    public class AccessSchedule : BaseEntity
    {
        [Key]
        public required string Code { get; set; }

        public required string Name { get; set; }

        public uint Id { get; set; }


        public virtual ICollection<AccessLevel>? AccessLevels { get; set; }
    }
}
