using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalModuleUser.Domain.Entities.AccountUser.Port.InterfacesServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalModuleUser.Infrastructure.Adapter.TokenAdapter
{
    public class TokenAdapterJWT: IJWTtokenService
    {
        private readonly IConfiguration _config;
        public TokenAdapterJWT(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string userName, IEnumerable<string> roles, string id)
        {
            var claims = new[]
          {
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                new Claim(ClaimTypes.Name, userName.ToString()),
                new Claim(ClaimTypes.UserData,id)

            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ApiSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                //issuer: "tuDominio.com",
                //audience: "tuDominio.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
