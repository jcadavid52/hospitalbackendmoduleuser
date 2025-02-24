using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Domain.Exceptions.UserExceptions;
using HospitalModuleUser.Domain.Exceptions;

namespace HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity
{
    public class ValidatorAccountUserEntity
    {
        const int minimalLengthFullName = 2;
        const int minimalLengthUserName = 6;
        const int minimalLengthPhoneNumber = 10;
        const int minimalLengthAddress = 5;
        const int minimalLengthEmail = 6;

        public static void ValidateFullName(string fullName)
        {

            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Esta propiedad no puede ser null o vacía.");

            if (fullName.Length < minimalLengthFullName)
                throw new StringLengthException($"'{fullName}' no puede tener una longitud de '{fullName.Length}'");
        }

        public static void ValidateUserName(string userName)
        {


            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Esta propiedad no puede estar vacía.");

            if (userName.Length < minimalLengthUserName)
                throw new StringLengthException($"'{userName}' no puede tener una longitud de '{userName.Length}'");

        }

        public static void ValidatePhoneNumber(string phoneNumber)
        {


            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Esta propiedad no puede estar vacía.");

            if (!IsValidPhoneNumber(phoneNumber))
                throw new PhoneNumberException($"el número de teléfono solo debe contener dígitos del 0-9");

            if (phoneNumber.Length < minimalLengthPhoneNumber)
                throw new StringLengthException($"'{phoneNumber}' no puede tener una longitud de '{phoneNumber.Length}'");

        }


        private static bool IsValidPhoneNumber(string number)
        {
            return !string.IsNullOrEmpty(number) && number.All(char.IsDigit);
        }

        public static void ValidateEmail(string email)
        {
            if (email.Length < minimalLengthEmail)
                throw new StringLengthException($"'{email}' no puede tener una longitud de '{email.Length}'");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Esta propiedad no puede estar vacía.");

        }

        public static void ValidateAdress(string adress)
        {
            if (adress.Length < minimalLengthAddress)
                throw new StringLengthException($"'{adress}' no puede tener una longitud de '{adress.Length}'");

            if (string.IsNullOrEmpty(adress))
                throw new ArgumentException("Esta propiedad no puede estar vacía.");

        }
    }
}
