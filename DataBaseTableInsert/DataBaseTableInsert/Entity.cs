using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseTableInsert
{
    [Table("access_history")]
    public class Entity
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }

        public int deviceId { get; set; }
        public int result { get; set; }
        public int authType { get; set; }
        public string imageFile { get; set; }
        public DateTime accessDt { get; set; }
        public int reason { get; set; }
        public string cardNo { get; set; }
    }
}
