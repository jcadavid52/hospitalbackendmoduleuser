using Microsoft.AspNetCore.Identity;

namespace HospitalModuleUser.Infra.Adapter.AccountUserAdapter
{
    public class IdentityAccountUserAdapter: IdentityUser
    {
        public string FullName { get; init; }
        public int Age { get; init; }
        public string Address { get; init; }
    }
}
