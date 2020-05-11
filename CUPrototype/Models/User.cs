using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUPrototype.Models
{

    [Table("tbl_user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
