
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Infrastructure.Adapter.AccountUserAdapter;

namespace HospitalModuleUser.Infrastructure.Port
{
    public interface IAccountUserAdapterFactory
    {
        IdentityAccountUserAdapter CreateMapIdentityUserAdapter(IdentityUserAdpaterDto user);
        IdentityUserAdpaterDto CreateMapIdentityUserDto(IdentityAccountUserAdapter identityUserAdapter);
        IdentityAccountUserAdapter CreateMapIdentityUserAdapter(AccountUserEntity user);
    }
}
