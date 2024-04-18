using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Mappers;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> logger;
        private readonly AuthorContextHandler AuthorContextHandler;

        private readonly CommonApply commonApply;

        private readonly AuthorApply authorApply;

        private readonly AuthorMapper authorMapper;

        public AuthorService(ILogger<AuthorService> logger, AuthorContextHandler AuthorContextHandler, CommonApply commonApply, AuthorApply authorApply, AuthorMapper authorMapper) 
        {
            this.logger = logger;
            this.AuthorContextHandler = AuthorContextHandler;
            this.commonApply = commonApply;
            this.authorApply = authorApply;
            this.authorMapper = authorMapper;
        }

        public async Task<ICollection<Author>> RetrieveAuthorList()
        {
            return await AuthorContextHandler.FindAll();
        }
        public async Task<Author?> RetrieveAuthor(string code)
        {
            return await AuthorContextHandler.FindByCondition(Author => Author.Code.Equals(code));
        }

        public async Task<Author> RegistAuthor(Author Author)
        {
            Author.Id = await AuthorContextHandler.FindByMaxId() + 1; 

            await AuthorContextHandler.Insert(Author);

            var authorDto = authorMapper.EntityToDomain(Author);

            await commonApply.DeviceApply((int deviceId) => authorApply.AuthorDeviceApply(authorDto));

            return Author;
        }

        public async Task UpdateAuthor(Author Author)
        {
            await AuthorContextHandler.Update(Author);

            // TODO : Device apply
        }

        public async Task DeleteAuthor(Author Author)
        {
            await AuthorContextHandler.Delete(Author);

            // TODO : Device apply
        }
    }
}
