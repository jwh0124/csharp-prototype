﻿using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("AccessSchedule")]
    public class AccessSchedule : BaseEntity
    {
        [Key]
        public string? Code { get; set; }
        
        public uint Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Schedule>? Schedules { get; set; }
    }
}
