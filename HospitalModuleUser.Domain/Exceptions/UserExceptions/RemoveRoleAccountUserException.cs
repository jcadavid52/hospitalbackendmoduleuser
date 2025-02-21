using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions.UserExceptions
{
    public class RemoveRoleAccountUserException : CoreBusinessException
    {
        public RemoveRoleAccountUserException()
        {
        }

        public RemoveRoleAccountUserException(string msg) : base(msg)
        {
        }

        public RemoveRoleAccountUserException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
