

using HospitalModuleUser.Domain.Exceptions.UserExceptions;
using HospitalModuleUser.Domain.Common;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Service
{
    [DomainService]
    public class AccountUserResgisterService
    {
        private readonly IAccountUserRepository _accountUserRespository;
       

        public AccountUserResgisterService(IAccountUserRepository accountUserRespository)
        {
            _accountUserRespository = accountUserRespository;
        }

        public async Task<AccountUserDto> ExecuteRegisterAsync(AccountUserEntity user, string password)
        {
            var resultRegister = await _accountUserRespository.AddAccountUser(user, password);

            if (!resultRegister.success || resultRegister.User == null || resultRegister == null )
            {
                foreach (var error in resultRegister.errors)
                {
                    throw new NoRegisterUserException($"No se pudo hacer el registro: {error}");
                }

            }

            var roles = await _accountUserRespository.AssignRoleAccountUser("Usuario", resultRegister.User.Id);

            var accountUserDto = new AccountUserDto(resultRegister.User.Id, resultRegister.User.FullName, resultRegister.User.UserName,
              resultRegister.User.Email, resultRegister.User.PhoneNumber, resultRegister.User.Age, resultRegister.User.Address, roles);

            return accountUserDto;
        }
    }
}
