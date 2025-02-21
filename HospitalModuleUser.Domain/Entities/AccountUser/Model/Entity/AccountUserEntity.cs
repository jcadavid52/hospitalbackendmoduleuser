
using AppHospitalPractice.Domain.Exceptions.UserExceptions;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity
{
    public class AccountUserEntity
    {
        const int minimalAge = 1;

        public string FullName { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public int Age { get; init; }
        public string Address { get; init; }

        public AccountUserEntity(string fullName, string userName, string email, string phoneNumber, int age, string address)
        {
            if (age < minimalAge)
                throw new UserAgeException($"La edad no puede ser menor a {minimalAge}");

            this.FullName = fullName;
            this.UserName = userName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Age = age;
            this.Address = address;
        }
    }
}
