using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHospitalPractice.Domain.Exceptions
{
    public class StringLengthException : CoreBusinessException
    {
        public StringLengthException()
        {
        }

        public StringLengthException(string msg) : base(msg)
        {
        }

        public StringLengthException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
