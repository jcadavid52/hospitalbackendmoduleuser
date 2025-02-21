using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Infra.Adapter.AccountUserAdapter;

namespace HospitalModuleUser.Infra.Port
{
    public interface IAccountUserAdapterFactory
    {
        IdentityAccountUserAdapter CreateMapIdentityUserAdapter(IdentityUserAdpaterDto user);
        IdentityUserAdpaterDto CreateMapIdentityUserDto(IdentityAccountUserAdapter identityUserAdapter);
        IdentityAccountUserAdapter CreateMapIdentityUserAdapter(AccountUserEntity user);
    }
}
