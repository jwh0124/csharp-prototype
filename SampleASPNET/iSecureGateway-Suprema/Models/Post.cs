using iSecureGateway_Suprema.Commons.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("Post")]
    public class Post : BaseEntity
    {
        [Key]
        public required string Code { get; set; }

        public required string Name { get; set; }

        public uint Id { get; set; }

        public ICollection<Author>? Authors { get; set; }

        public ICollection<PostAuthor>? PostAuthors { get; set; }
    }
}
