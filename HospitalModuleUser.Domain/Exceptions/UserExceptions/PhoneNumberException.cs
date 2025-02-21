


namespace HospitalModuleUser.Domain.Exceptions.UserExceptions
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
