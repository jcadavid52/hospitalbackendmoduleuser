

namespace HospitalModuleUser.Domain.Exceptions
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
