
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Mappers
{
    public class AuthorMapper {
        public AuthorDto EntityToDomain(Author author) {
            return new AuthorDto(){ Name = author.Name, Code = author.Code };
        }
    }
}