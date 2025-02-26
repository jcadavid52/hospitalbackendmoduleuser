using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalModuleUser.ApiTests.AccountAppi
{
     class UsingAccountRespository
    {
        public async Task<AccountUserEntity> RegisterAcountUser(AccountUserEntity user, string password, IServiceScope scope)
        {
            var accountUserRepository = scope.ServiceProvider.GetRequiredService<IAccountUserRepository>();

            var userRegistered = await accountUserRepository.AddAccountUser(user, password);


            return new AccountUserEntity(userRegistered.User.FullName, userRegistered.User.UserName, userRegistered.User.Email,
                userRegistered.User.PhoneNumber, userRegistered.User.Age, userRegistered.User.Address)
            {
                Id = userRegistered.User.Id
            };
        }

        public async Task<IEnumerable<string>> GetAllRolesByUser(IServiceScope scope, string id)
        {
            var accountUserRepository = scope.ServiceProvider.GetRequiredService<IAccountUserRepository>();

            var identityUserAdapter = await accountUserRepository.GetAccountUserById(id);

            return await accountUserRepository.GetAccountUserRoles(identityUserAdapter.User);
        }

        public async Task<IEnumerable<string>> AssignRoleAccountUser(string nameRole, string idUser, IServiceScope scope)
        {
            var accountUserRepository = scope.ServiceProvider.GetRequiredService<IAccountUserRepository>();


            var roles = await accountUserRepository.AssignRoleAccountUser(nameRole, idUser);

            return roles;
        }
    }
}
