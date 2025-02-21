

using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories
{
    public interface IAccountUserRepository
    {
        Task<ResponseRepositoryAccountRegisterDto> AddAccountUser(AccountUserEntity user, string password);
        Task<IEnumerable<string>> AssignRoleAccountUser(string nameRole, string idUser);
    }
}
