using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;

namespace HospitalModuleUser.DomainTest.AccountUser.Model.Entity
{
    public class AccountIdentityUserDataBuilder
    {
        private  string _id = "user-123";
        private  string _fullName = "María González";
        private  int _age = 29;
        private  string _address = "Calle Ejemplo 456, Ciudad Fantasía";
        private  string _userName = "mariagonzalez";
        private  string _normalizedUserName = "MARIAGONZALEZ";
        private  string _email = "maria.gonzalez@example.com";
        private  string _normalizedEmail = "MARIA.GONZALEZ@EXAMPLE.COM";
        private  bool _emailConfirmed = true;
        private  string _passwordHash = "AQAAAAEAACcQAAAAEJzTn5H3v8Z0LJ1Q4gP1q1YQhFJ8WZ5J1k5F5Ff5A==";
        private  string _securityStamp = "security-stamp-123";
        private  string _concurrencyStamp = "concurrency-stamp-123";
        private  string _phoneNumber = "555-9876";
        private  bool _phoneNumberConfirmed = true;
        private  bool _twoFactorEnabled = false;
        private  DateTimeOffset? _lockoutEnd = null;
        private  bool _lockoutEnabled = true;
        private  int _accessFailedCount = 0;

        private AccountUserEntity _accountUserEntity;
        public AccountIdentityUserDataBuilder(AccountUserEntity accountUserEntity)
        {
            _accountUserEntity = accountUserEntity;
        }


        public AccountIdentityUserDataBuilder WithId()
        {
            _id = _accountUserEntity.Id;
            return this;
        }

        public AccountIdentityUserDataBuilder WithFullName()
        {
            _fullName = _accountUserEntity.FullName;
            return this;
        }

        public AccountIdentityUserDataBuilder WithAge()
        {
            _age = _accountUserEntity.Age;
            return this;
        }

        public AccountIdentityUserDataBuilder WithAddress()
        {
            _address = _accountUserEntity.Address;
            return this;
        }

        public AccountIdentityUserDataBuilder WithUserName()
        {
            _userName = _accountUserEntity.UserName;
            return this;
        }

        public AccountIdentityUserDataBuilder WithNormalizedUserName()
        {
            _normalizedUserName = _accountUserEntity.UserName.ToUpper();
            return this;
        }

        public AccountIdentityUserDataBuilder WithEmail()
        {
            _email = _accountUserEntity.Email;
            return this;
        }

        public AccountIdentityUserDataBuilder WithNormalizedEmail()
        {
            _normalizedEmail = _accountUserEntity.Email.ToUpper();
            return this;
        }

        public AccountIdentityUserDataBuilder WithEmailConfirmed(bool emailConfirmed)
        {
            _emailConfirmed = emailConfirmed;
            return this;
        }

        public AccountIdentityUserDataBuilder WithPasswordHash(string passwordHash)
        {
            _passwordHash = passwordHash;
            return this;
        }

        public AccountIdentityUserDataBuilder WithSecurityStamp(string securityStamp)
        {
            _securityStamp = securityStamp;
            return this;
        }

        public AccountIdentityUserDataBuilder WithConcurrencyStamp(string concurrencyStamp)
        {
            _concurrencyStamp = concurrencyStamp;
            return this;
        }

        public AccountIdentityUserDataBuilder WithPhoneNumber()
        {
            _phoneNumber = _accountUserEntity.PhoneNumber;
            return this;
        }

        public AccountIdentityUserDataBuilder WithPhoneNumberConfirmed(bool phoneNumberConfirmed)
        {
            _phoneNumberConfirmed = phoneNumberConfirmed;
            return this;
        }

        public AccountIdentityUserDataBuilder WithTwoFactorEnabled(bool twoFactorEnabled)
        {
            _twoFactorEnabled = twoFactorEnabled;
            return this;
        }

        public AccountIdentityUserDataBuilder WithLockoutEnd()
        {
            return this;
        }

        public AccountIdentityUserDataBuilder WithLockoutEnabled(bool lockoutEnabled)
        {
            _lockoutEnabled = lockoutEnabled;
            return this;
        }

        public AccountIdentityUserDataBuilder WithAccessFailedCount(int accessFailedCount)
        {
            _accessFailedCount = accessFailedCount;
            return this;
        }

        public IdentityUserAdpaterDto Builder()
        {
            return new IdentityUserAdpaterDto(
                        Id: _id,
                        FullName: _fullName,
                        Age: _age,
                        Address: _address,
                        UserName: _userName,
                        NormalizedUserName: _normalizedUserName,
                        Email: _email,
                        NormalizedEmail: _normalizedEmail,
                        EmailConfirmed: _emailConfirmed,
                        PasswordHash: _passwordHash,
                        SecurityStamp: _securityStamp,
                        ConcurrencyStamp: _concurrencyStamp,
                        PhoneNumber: _phoneNumber,
                        PhoneNumberConfirmed: _phoneNumberConfirmed,
                        TwoFactorEnabled: _twoFactorEnabled,
                        LockoutEnd: _lockoutEnd,
                        LockoutEnabled: _lockoutEnabled,
                        AccessFailedCount: _accessFailedCount
                    );
        }
    }
}
