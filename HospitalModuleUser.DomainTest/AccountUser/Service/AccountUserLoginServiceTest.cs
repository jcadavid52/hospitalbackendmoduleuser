using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesServices;
using HospitalModuleUser.Domain.Entities.AccountUser.Service;
using HospitalModuleUser.DomainTest.AccountUser.Model.Entity;
using NSubstitute;

namespace HospitalModuleUser.DomainTest.AccountUser.Service
{
    public class AccountUserLoginServiceTest
    {
        readonly IAccountUserRepository _accountUserRepository;
        readonly AccountUserLoginService _accountUserLoginService;
        readonly IJWTtokenService _iJWTtokenService;
        public AccountUserLoginServiceTest()
        {
            _accountUserRepository = Substitute.For<IAccountUserRepository>();
            _iJWTtokenService = Substitute.For<IJWTtokenService>();
            _accountUserLoginService = new AccountUserLoginService(_accountUserRepository,_iJWTtokenService);
        }

        [Fact]
        public async Task ExecuteAsync_Success()
        {
            var accountUser = new AccountUserDataBuilder().Build();
            var accountIdentityUser = new AccountIdentityUserDataBuilder(accountUser)
                .WithId()
                .WithFullName()
                .WithAge()
                .WithAddress()
                .WithUserName()
                .WithNormalizedUserName()
                .WithEmail()
                .WithNormalizedEmail()
                .WithPhoneNumber()
                .Builder();

            _accountUserRepository.GetAccountUserByUserName(Arg.Any<string>())
                .Returns(new IndetityFoundDto(accountIdentityUser,true));

            _accountUserRepository.LoginAccountUser(Arg.Any<IdentityUserAdpaterDto>(), "Colombia2025*")
                .Returns(true);

            _accountUserRepository.GetAccountUserRoles(Arg.Any<IdentityUserAdpaterDto>())
                .Returns(new List<string> { "Usuario" });

            _iJWTtokenService.GenerateToken(Arg.Any<string>(), Arg.Any<IEnumerable<string>>(), Arg.Any<string>())
                .Returns("token123");
            

            var result = await _accountUserLoginService.ExecuteAsync(accountUser.UserName, "Colombia2025*");



            Assert.NotNull(result);
            Assert.Equal(result.UserDto.UserName, accountUser.UserName);
            Assert.Equal(result.token, "token123");
        }
    }
}
