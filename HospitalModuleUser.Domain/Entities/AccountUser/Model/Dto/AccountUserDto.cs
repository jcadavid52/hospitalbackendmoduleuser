using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto
{
    public record AccountUserDto(string id, string FullName, string UserName, string Email, string PhoneNumber, int Age, string Address, IEnumerable<string> roles);

}
