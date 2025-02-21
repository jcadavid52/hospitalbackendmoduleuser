using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using MediatR;

namespace HospitalModuleUser.Applica.Account.CommandHandler.Command
{
  
        public record AccountRegisterCommand(string fullName, string email, string PhoneNumber, int age, string address, string password, string confirmPassword) : IRequest<AccountUserDto>;
    
}
