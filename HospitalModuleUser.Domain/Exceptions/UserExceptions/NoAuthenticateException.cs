using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions.UserExceptions
{
    public class NoAuthenticateException : CoreBusinessException
    {
        public NoAuthenticateException()
        {
        }

        public NoAuthenticateException(string msg) : base(msg)
        {
        }

        public NoAuthenticateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
