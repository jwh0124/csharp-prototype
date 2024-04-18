using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Interfaces
{
    public interface IPostService
    {
        Task<ICollection<Post>> RetrievePostList();

        Task<Post?> RetrievePost(string code);

        Task<Post> RegistPost(Post post);

        Task UpdatePost(Post post);

        Task DeletePost(Post post);
    }
}
