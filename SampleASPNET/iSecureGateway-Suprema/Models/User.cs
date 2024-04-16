using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Key]
        public required string Code { get; set; }
        
        public uint Id { get; set; }

        public required string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? Pin { get; set; }

        public virtual ICollection<AccessGroup> AccessGroups { get; set; } = [];

        public virtual ICollection<Card> Cards { get; set; } = [];
    }
}
