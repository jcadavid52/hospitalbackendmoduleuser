using Microsoft.AspNetCore.Identity;

namespace HospitalModuleUser.Infrastructure.Adapter.AccountUserAdapter
{
    public class IdentityAccountUserAdapter: IdentityUser
    {
        public string FullName { get; init; }
        public int Age { get; init; }
        public string Address { get; init; }
    }
}
