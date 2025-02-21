



namespace HospitalModuleUser.Domain.Exceptions.UserExceptions
{
    public class UserAgeException:CoreBusinessException
    {
        public UserAgeException()
        {
        }

        public UserAgeException(string msg) : base(msg)
        {
        }

        public UserAgeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
