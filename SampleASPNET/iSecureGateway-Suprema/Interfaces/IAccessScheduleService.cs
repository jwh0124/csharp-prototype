using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Interfaces
{
    public interface IAccessScheduleService
    {
        Task<ICollection<AccessSchedule>> RetrieveAccessScheduleList();

        Task<AccessSchedule?> RetrieveAccessSchedule(string code);

        Task<AccessSchedule> RegistAccessSchedule(AccessSchedule accessSchedule);

        Task UpdateAccessSchedule(AccessSchedule accessSchedule);

        Task DeleteAccessSchedule(AccessSchedule accessSchedule);
    }
}
