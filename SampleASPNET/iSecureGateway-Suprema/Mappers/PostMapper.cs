
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Mappers
{
    public class PostMapper {
        public PostDto EntityToDomain(Post post) {
            return new PostDto(){ Name = post.Name, Code = post.Code };
        }
    }
}