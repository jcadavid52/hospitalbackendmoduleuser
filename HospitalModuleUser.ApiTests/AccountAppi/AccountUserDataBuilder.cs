

using HospitalModuleUser.Application.Account.CommandHandler.Command;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;

namespace HospitalModuleUser.ApiTests.AccountAppi
{
    internal class AccountUserDataBuilder
    {
        private string _Id = Guid.NewGuid().ToString();
        private string _FullName = "Name Test";
        private string _UserName = "emailtest@test.com";
        private string _Email = "emailtest@test.com";
        private string _PhoneNumber = "3128587474";
        private int _Age = 36;
        private string _Address = "Calle test";
        private string _Password = "Password2025*";
        private string _ConfirmPassword = "Password2025*";

        public AccountUserDataBuilder WithId(string id)
        {
            _Id = id;
            return this;
        }

        public AccountUserDataBuilder WithFullName(string fullName)
        {
            _FullName = fullName;
            return this;
        }
        public AccountUserDataBuilder WithUserName(string userName)
        {
            _UserName = userName;
            return this;
        }

        public AccountUserDataBuilder WithEmail(string email)
        {
            _Email = email;
            return this;
        }
        public AccountUserDataBuilder WithPhoneNumber(string phoneNumber)
        {
            _PhoneNumber = phoneNumber;
            return this;
        }
        public AccountUserDataBuilder WithAge(int age)
        {
            _Age = age;
            return this;
        }
        public AccountUserDataBuilder WithAge(string address)
        {
            _Address = address;
            return this;
        }
        public AccountUserDataBuilder WithPassword(string password)
        {
            _Password = password;
            return this;
        }

        public AccountUserDataBuilder WithConfirmPassword(string confirmPassword)
        {
            _ConfirmPassword = confirmPassword;
            return this;
        }

        public AccountUserEntity Build()
        {

            return new AccountUserEntity(_Id, _UserName, _Email, _PhoneNumber, _Age, _Address);
        }

        public AccountRegisterCommand BuildCommand()
        {
            return new AccountRegisterCommand(_FullName, _Email, _PhoneNumber, _Age, _Address, _Password, _ConfirmPassword);
        }
    }
}
