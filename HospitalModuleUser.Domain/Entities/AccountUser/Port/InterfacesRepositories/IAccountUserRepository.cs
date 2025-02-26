

using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories
{
    public interface IAccountUserRepository
    {
        Task<ResponseRepositoryAccountRegisterDto> AddAccountUser(AccountUserEntity user, string password);
        Task<IEnumerable<string>> AssignRoleAccountUser(string nameRole, string idUser);
        Task<bool> LoginAccountUser(IdentityUserAdpaterDto user, string password);
        Task<IEnumerable<string>> GetAccountUserRoles(IdentityUserAdpaterDto user);
        Task<IndetityFoundDto> GetAccountUserByUserName(string userName);
        Task<IndetityFoundDto> GetAccountUserById(string id);
    }
}
