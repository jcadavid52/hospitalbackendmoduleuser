using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
