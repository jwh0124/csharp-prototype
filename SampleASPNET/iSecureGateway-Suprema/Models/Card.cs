using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Commons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSecureGateway_Suprema.Models
{
    [Table("Card")]
    public class Card : BaseEntity
    {
        [Key]
        public string? CardNo { get; set; }

        public CardType CardType { get; set; }

        public string? UserCode { get; set; }
    }
}
