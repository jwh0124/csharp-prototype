using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Interfaces
{
    public interface IAccessLevelService
    {
        Task<ICollection<AccessLevel>> RetrieveAccessLevelList();

        Task<AccessLevel?> RetrieveAccessLevel(string code);

        Task<AccessLevel> RegistAccessLevel(AccessLevel accessLevel);

        Task UpdateAccessLevel(string code, AccessLevel accessLevel);

        Task DeleteAccessLevel(string code);
    }
}
