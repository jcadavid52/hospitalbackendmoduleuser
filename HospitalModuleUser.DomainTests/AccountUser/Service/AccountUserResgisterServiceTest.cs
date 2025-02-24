
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesRepositories;
using HospitalModuleUser.Domain.Entities.AccountUser.Service;
using HospitalModuleUser.DomainTest.AccountUser.Model.Entity;
using NSubstitute;

namespace HospitalModuleUser.DomainTest.AccountUser.Service
{
    public class AccountUserResgisterServiceTest
    {
        readonly IAccountUserRepository _accountUserRepository;
        readonly AccountUserResgisterService  _accountUserResgisterService;

        public AccountUserResgisterServiceTest()
        {
            _accountUserRepository = Substitute.For<IAccountUserRepository>();
            _accountUserResgisterService = new AccountUserResgisterService(_accountUserRepository);
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

            _accountUserRepository.AddAccountUser(Arg.Any<AccountUserEntity>(), Arg.Any<string>())
                .Returns(new ResponseRepositoryAccountRegisterDto(accountIdentityUser, true, null));

            _accountUserRepository.AssignRoleAccountUser(Arg.Any<string>(), Arg.Any<string>())
                .Returns(new List<string> { "Usuario" });

            var registerResult =
                await _accountUserResgisterService.ExecuteRegisterAsync(accountUser,"Colombia2025*");
            var expectativeRole = registerResult.roles.FirstOrDefault();

            Assert.NotNull(registerResult);
            Assert.Equal(registerResult.id, accountUser.Id);
            Assert.True(expectativeRole != null);
            Assert.Equal(expectativeRole, "Usuario");
            
        }
    }
}
