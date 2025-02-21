using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions.UserExceptions
{
    public class PhoneNumberException:CoreBusinessException
    {
        public PhoneNumberException()
        {
        }

        public PhoneNumberException(string msg) : base(msg)
        {
        }

        public PhoneNumberException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
