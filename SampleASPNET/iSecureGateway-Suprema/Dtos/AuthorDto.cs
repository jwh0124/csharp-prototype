using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.DTO
{
    public class AuthorDto
    {
        public string? Code { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
