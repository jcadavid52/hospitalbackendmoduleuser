using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions.UserExceptions
{
    public class NoAssignRoleException : CoreBusinessException
    {
        public NoAssignRoleException()
        {
        }

        public NoAssignRoleException(string msg) : base(msg)
        {
        }

        public NoAssignRoleException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
