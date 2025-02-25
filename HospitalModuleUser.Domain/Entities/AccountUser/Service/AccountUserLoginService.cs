

using HospitalModuleUser.Domain.Common;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesServices;
using HospitalModuleUser.Domain.Exceptions.UserExceptions;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Service
{
    [DomainService]
    public class AccountUserLoginService
    {
        private readonly IAccountUserRepository _accountUserRespository;
        private readonly IJWTtokenService _jwtToken;

        public AccountUserLoginService(IAccountUserRepository accountUserRespository, IJWTtokenService jwtToken)
        {
            _accountUserRespository = accountUserRespository;
            _jwtToken = jwtToken;
        }
        public async Task<ResponseAccessDto> ExecuteAsync(string userName, string password)
        {
            var userFound = await _accountUserRespository.GetAccountUserByUserName(userName);

            if (userFound.User == null || !userFound.success || userFound == null)
            {
                throw new NoAuthenticateException("Clave o usuario inválido");
            }

            var resultAccess = await _accountUserRespository.LoginAccountUser(userFound.User, password);


            if (!resultAccess)
            {
                throw new NoAuthenticateException("Clave o usuario inválido");
            }

            var roles = await _accountUserRespository.GetAccountUserRoles(userFound.User);

            var userDto = new AccountUserDto(userFound.User.Id, userFound.User.FullName, userFound.User.UserName, userFound.User.Email, userFound.User.PhoneNumber,
                userFound.User.Age, userFound.User.Address, roles);

            string token = _jwtToken.GenerateToken(userFound.User.UserName, roles, userFound.User.Id);


            return new ResponseAccessDto(userDto, token);
        }
    }
}
