using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class AccessLevelService : IAccessLevelService
    {
        private readonly ILogger<AccessLevelService> logger;
        private readonly AccessLevelContextHandler accessLevelContextHandler;

        public AccessLevelService(ILogger<AccessLevelService> logger, AccessLevelContextHandler accessLevelContextHandler)
        {
            this.logger = logger;
            this.accessLevelContextHandler = accessLevelContextHandler;
        }

        public async Task<ICollection<AccessLevel>> RetrieveAccessLevelList()
        {
            return await accessLevelContextHandler.FindAll();
        }
        public async Task<AccessLevel?> RetrieveAccessLevel(string code)
        {
            return await accessLevelContextHandler.FindByCondition(entity => entity.Code.Equals(code));
        }

        public async Task<AccessLevel> RegistAccessLevel(AccessLevel accessLevel)
        {
            await accessLevelContextHandler.Insert(accessLevel);

            // TODO : Device apply

            return accessLevel;
        }

        public async Task UpdateAccessLevel(string code, AccessLevel accessLevel)
        {
            var findAccessLevel = await accessLevelContextHandler.FindByCondition(entity => entity.Code.Equals(code));
            if (findAccessLevel != null)
            {
                // TODO : Child update
                await accessLevelContextHandler.Update(accessLevel);

                // TODO : Device apply
            }
        }

        public async Task DeleteAccessLevel(string code)
        {
            var findAccessGroup = await accessLevelContextHandler.FindByCondition(entity => entity.Code.Equals(code));
            if (findAccessGroup != null)
            {
                await accessLevelContextHandler.Delete(findAccessGroup);

                // TODO : Device apply
            }
        }
    }
}
