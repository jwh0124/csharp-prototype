using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Interfaces
{
    public interface IAccessGroupService
    {
        Task<ICollection<AccessGroup>> RetrieveAccessGroupList();

        Task<AccessGroup?> RetrieveAccessGroup(string code);

        Task<AccessGroup> RegistAccessGroup(AccessGroup accessGroup);

        Task UpdateAccessGroup(string code, AccessGroup accessGroup);

        Task DeleteAccessGroup(string code);
    }
}
