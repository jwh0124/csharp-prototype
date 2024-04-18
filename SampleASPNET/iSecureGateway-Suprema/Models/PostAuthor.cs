using iSecureGateway_Suprema.Commons.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("PostAuthor")]
    public class PostAuthor : BaseEntity
    {
        public required string PostCode { get; set; }

        public required string AuthorCode { get; set; }
    }
}
