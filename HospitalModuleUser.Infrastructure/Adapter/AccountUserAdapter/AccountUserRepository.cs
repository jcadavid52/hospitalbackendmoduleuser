
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;
using HospitalModuleUser.Infrastructure.Port;
using Microsoft.AspNetCore.Identity;

namespace HospitalModuleUser.Infrastructure.Adapter.AccountUserAdapter
{
    [Repository]
    public class AccountUserRepository : IAccountUserRepository
    {
        private readonly UserManager<IdentityAccountUserAdapter> _userManager;
        private readonly IAccountUserAdapterFactory _accountUserAdapterFactory;

        public AccountUserRepository(UserManager<IdentityAccountUserAdapter> userManager, IAccountUserAdapterFactory accountUserAdapterFactory)
        {
            _userManager = userManager;
            _accountUserAdapterFactory = accountUserAdapterFactory;

        }
        public async Task<ResponseRepositoryAccountRegisterDto> AddAccountUser(AccountUserEntity user, string password)
        {
            List<string> errors = new List<string>();

            var identityUserAdapter = _accountUserAdapterFactory.CreateMapIdentityUserAdapter(user);

            var registerResult = await _userManager.CreateAsync(identityUserAdapter, password);


            if (!registerResult.Succeeded)
            {
                foreach (var error in registerResult.Errors)
                {
                    var valueError = error.Description;
                    errors.Add(valueError);
                }

                return new ResponseRepositoryAccountRegisterDto(null, registerResult.Succeeded, errors);
            }



            var userRegistered = _accountUserAdapterFactory.CreateMapIdentityUserDto(identityUserAdapter);

            return new ResponseRepositoryAccountRegisterDto(userRegistered, registerResult.Succeeded, null);
        }

        public async Task<IEnumerable<string>> AssignRoleAccountUser(string nameRole, string idUser)
        {
            var userFind = await _userManager.FindByIdAsync(idUser);

            var result = await _userManager.AddToRoleAsync(userFind, nameRole);

            if (!result.Succeeded)
            {
                return [];

            }

            return await _userManager.GetRolesAsync(userFind);
        }

        public async Task<IndetityFoundDto> GetAccountUserById(string id)
        {
            var identityUserAdapter = await _userManager.FindByIdAsync(id);


            if (identityUserAdapter == null)
            {
                return new IndetityFoundDto(null, false);
            }

            var userFound = _accountUserAdapterFactory.CreateMapIdentityUserDto(identityUserAdapter);



            return new IndetityFoundDto(userFound, true);
        }

        public async Task<IndetityFoundDto> GetAccountUserByUserName(string userName)
        {
            var identityUserAdapter = await _userManager.FindByNameAsync(userName);

            if (identityUserAdapter == null)
            {
                return new IndetityFoundDto(null, false);
            }


            var userFound = _accountUserAdapterFactory.CreateMapIdentityUserDto(identityUserAdapter);



            return new IndetityFoundDto(userFound, true);
        }

        public async Task<IEnumerable<string>> GetAccountUserRoles(IdentityUserAdpaterDto user)
        {
            var identityUserAdapter = _accountUserAdapterFactory.CreateMapIdentityUserAdapter(user);

            return await _userManager.GetRolesAsync(identityUserAdapter);
        }

        public async Task<bool> LoginAccountUser(IdentityUserAdpaterDto user, string password)
        {
            var identityUserAdapter = _accountUserAdapterFactory.CreateMapIdentityUserAdapter(user);

            var success = await _userManager.CheckPasswordAsync(identityUserAdapter, password);

            return success;
        }
    }
}
