

namespace HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto
{
    public record ResponseRepositoryAccountRegisterDto(IdentityUserAdpaterDto? User, bool success, IEnumerable<string>? errors);
    //public record IdentityResultDto(bool success, IEnumerable<string>? errors);
    public record IndetityFoundDto(IdentityUserAdpaterDto? User, bool success);
}
