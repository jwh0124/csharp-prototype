using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class AccessGroupService : IAccessGroupService
    {
        private readonly ILogger<AccessGroupService> logger;
        private readonly AccessGroupContextHandler accessGroupContextHandler;
        private readonly AccessLevelContextHandler accessLevelContextHandler;

        public AccessGroupService(ILogger<AccessGroupService> logger, AccessGroupContextHandler accessGroupContextHandler,
                                    AccessLevelContextHandler accessLevelContextHandler)
        {
            this.logger = logger;
            this.accessGroupContextHandler = accessGroupContextHandler;
            this.accessLevelContextHandler = accessLevelContextHandler;
        }

        public async Task<ICollection<AccessGroup>> RetrieveAccessGroupList()
        {
            return await accessGroupContextHandler.FindAll();
        }
        public async Task<AccessGroup?> RetrieveAccessGroup(string code)
        {
            return await accessGroupContextHandler.FindByCondition(entity => entity.Code.Equals(code));
        }

        public async Task<AccessGroup> RegistAccessGroup(AccessGroup accessGroup)
        {
            accessGroup.Id = await accessGroupContextHandler.FindByMaxId() + 1;

            if (accessGroup.AccessLevels?.Count > 0)
            {
                ICollection<AccessLevel> accessLevels = [];
                accessGroup.AccessLevels.ToList().ForEach(async accessLevel =>
                {
                    var findAccessLevel = await accessLevelContextHandler.FindByCondition(entity => entity.Code.Equals(accessLevel.Code));
                    if (findAccessLevel != default(AccessLevel))
                    {
                        accessLevels.Add(findAccessLevel);
                    }
                });
                accessGroup.AccessLevels = accessLevels;
            }

            await accessGroupContextHandler.Insert(accessGroup);

            
            // TODO : Device apply

            return accessGroup;
        }

        public async Task UpdateAccessGroup(AccessGroup accessGroup)
        {
            if (accessGroup.AccessLevels?.Count > 0)
            {
                ICollection<AccessLevel> accessLevels = [];
                accessGroup.AccessLevels.ToList().ForEach(async accessLevel =>
                {
                    var findAccessLevel = await accessLevelContextHandler.FindByCondition(entity => entity.Code.Equals(accessLevel.Code));
                    if (findAccessLevel != default(AccessLevel))
                    {
                        accessLevels.Add(findAccessLevel);
                    }
                });
                accessGroup.AccessLevels = accessLevels;
            }

            await accessGroupContextHandler.Update(accessGroup);
        }


        public async Task DeleteAccessGroup(AccessGroup accessGroup)
        {
            await accessGroupContextHandler.Delete(accessGroup);
        }
    }
}
