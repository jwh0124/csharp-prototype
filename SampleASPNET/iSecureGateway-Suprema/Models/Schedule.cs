using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("Schedule")]
    public class Schedule : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        
        public uint Id { get; set; }

        public string? Name { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string? StartTime { get; set; }

        public string? EndTime { get; set; }
    }
}
