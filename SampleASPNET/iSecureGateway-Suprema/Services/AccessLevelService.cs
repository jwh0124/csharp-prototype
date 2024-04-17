using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class AccessLevelService : IAccessLevelService
    {
        private readonly ILogger<AccessLevelService> logger;
        private readonly AccessLevelContextHandler accessLevelContextHandler;
        private readonly AccessScheduleContextHandler accessScheduleContextHandler;

        public AccessLevelService(ILogger<AccessLevelService> logger, AccessLevelContextHandler accessLevelContextHandler, AccessScheduleContextHandler accessScheduleContextHandler)
        {
            this.logger = logger;
            this.accessLevelContextHandler = accessLevelContextHandler;
            this.accessScheduleContextHandler = accessScheduleContextHandler;
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
            accessLevel.Id = await accessLevelContextHandler.FindByMaxId() + 1;

            if (accessLevel.AccessSchedule != null)
            {
                var findAccessSchedule = await accessScheduleContextHandler.FindByCondition(entity => entity.Code.Equals(accessLevel.AccessSchedule.Code));
                if (findAccessSchedule != null)
                {
                    accessLevel.AccessSchedule = findAccessSchedule;
                }
            }

            await accessLevelContextHandler.Insert(accessLevel);

            // TODO : Device apply

            return accessLevel;
        }

        public async Task UpdateAccessLevel(AccessLevel accessLevel)
        {
            if (accessLevel.AccessSchedule != null)
            {
                var findAccessSchedule = await accessScheduleContextHandler.FindByCondition(entity => entity.Code.Equals(accessLevel.AccessSchedule.Code));
                if (findAccessSchedule != null)
                {
                    accessLevel.AccessSchedule = findAccessSchedule;
                }
            }

            await accessLevelContextHandler.Update(accessLevel);
        }

        public async Task DeleteAccessLevel(AccessLevel accessLevel)
        {
            await accessLevelContextHandler.Delete(accessLevel);
        }
    }
}
