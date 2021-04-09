using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicePrototype.Models
{
    [Table("tbl_menus")]
    public class Menu
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
    }
}
