using iSecureGateway_Suprema.Commons.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("Author")]
    public class Author : BaseEntity
    {
        [Key]
        public required string Code { get; set; }

        public required string Name { get; set; }

        public uint Id { get; set; }

        public ICollection<Post>? Posts{ get; set; }

        public ICollection<PostAuthor>? PostAuthors { get; set; }
    }
}
