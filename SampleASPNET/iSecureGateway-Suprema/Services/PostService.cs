using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Mappers;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> logger;
        private readonly PostContextHandler PostContextHandler;
        private readonly PostMapper postMapper;

        private readonly PostApply postApply;
        private readonly CommonApply commonApply;

        public PostService(ILogger<PostService> logger, PostContextHandler PostContextHandler, PostMapper postMapper, CommonApply commonApply, PostApply postApply)
        {
            this.logger = logger;
            this.PostContextHandler = PostContextHandler;
            this.postMapper = postMapper;
            this.commonApply = commonApply;
            this.postApply = postApply;
        }

        public async Task<ICollection<Post>> RetrievePostList()
        {
            return await PostContextHandler.FindAll();
        }
        public async Task<Post?> RetrievePost(string code)
        {
            return await PostContextHandler.FindByCondition(Post => Post.Code.Equals(code));
        }

        public async Task<Post> RegistPost(Post Post)
        {
            Post.Id = await PostContextHandler.FindByMaxId() + 1; 

            await PostContextHandler.Insert(Post);

            var postDto = postMapper.EntityToDomain(Post);

            await commonApply.DeviceApply((int deviceId) => postApply.PostDeviceApply(postDto));

            return Post;
        }

        public async Task UpdatePost(Post Post)
        {
            await PostContextHandler.Update(Post);

            // TODO : Device apply
        }

        public async Task DeletePost(Post Post)
        {
            await PostContextHandler.Delete(Post);

            // TODO : Device apply
        }
    }
}
