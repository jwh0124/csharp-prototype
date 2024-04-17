using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Services
{
    public class AccessScheduleService : IAccessScheduleService
    {
        private readonly ILogger<AccessScheduleService> logger;
        private readonly AccessScheduleContextHandler accessScheduleContextHandler;

        public AccessScheduleService(ILogger<AccessScheduleService> logger, AccessScheduleContextHandler accessScheduleContextHandler)
        {
            this.logger = logger;
            this.accessScheduleContextHandler = accessScheduleContextHandler;
        }

        public async Task<ICollection<AccessSchedule>> RetrieveAccessScheduleList()
        {
            return await accessScheduleContextHandler.FindAll();
        }
        public async Task<AccessSchedule?> RetrieveAccessSchedule(string code)
        {
            return await accessScheduleContextHandler.FindByCondition(accessSchedule => accessSchedule.Code.Equals(code));
        }

        public async Task<AccessSchedule> RegistAccessSchedule(AccessSchedule accessSchedule)
        {
            accessSchedule.Id = await accessScheduleContextHandler.FindByMaxId() + 1; 

            await accessScheduleContextHandler.Insert(accessSchedule);

            // TODO : Device apply

            return accessSchedule;
        }

        public async Task UpdateAccessSchedule(AccessSchedule accessSchedule)
        {
            await accessScheduleContextHandler.Update(accessSchedule);

            // TODO : Device apply
        }

        public async Task DeleteAccessSchedule(AccessSchedule accessSchedule)
        {
            await accessScheduleContextHandler.Delete(accessSchedule);

            // TODO : Device apply
        }
    }
}
