using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto
{
    public record ResponseRepositoryAccountRegisterDto(IdentityUserAdpaterDto? User, bool success, IEnumerable<string>? errors);
    //public record IdentityResultDto(bool success, IEnumerable<string>? errors);
    //public record IndetityFoundDto(IdentityUserAdpaterDto? User, bool success);
}
