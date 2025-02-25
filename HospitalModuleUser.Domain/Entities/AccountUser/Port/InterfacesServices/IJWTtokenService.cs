

namespace HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesServices
{
    public interface IJWTtokenService
    {
        string GenerateToken(string userName, IEnumerable<string> roles, string id);
    }
}
