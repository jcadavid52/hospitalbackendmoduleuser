

using AppHospitalPractice.Domain.Exceptions;

namespace HospitalModuleUser.Domain.Exceptions.UserExceptions
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
