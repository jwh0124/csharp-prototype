using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.DTO
{
    public class PostDto
    {
        public string? Code { get; set; }

        public required string Name { get; set; }

        public ICollection<AuthorDto>? Authors  { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
