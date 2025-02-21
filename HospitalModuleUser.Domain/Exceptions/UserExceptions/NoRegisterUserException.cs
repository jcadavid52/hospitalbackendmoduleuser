using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions.UserExceptions
{
    public class NoRegisterUserException : CoreBusinessException
    {
        public NoRegisterUserException()
        {
        }

        public NoRegisterUserException(string msg) : base(msg)
        {
        }

        public NoRegisterUserException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
