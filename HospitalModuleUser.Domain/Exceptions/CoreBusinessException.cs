using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions
{
    public class CoreBusinessException : Exception
    {
        public CoreBusinessException()
        {

        }
        public CoreBusinessException(string message) : base(message)
        {
        }

        public CoreBusinessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
