using FluentValidation;
using HospitalModuleUser.Applica.Account.CommandHandler.Command;

namespace HospitalModuleUser.Api.ApiHandlers.AccountApi
{
    public class AccountUserRegisterCommandValidator: AbstractValidator<AccountRegisterCommand>
    {
        public AccountUserRegisterCommandValidator()
        {
            RuleFor(command => command.fullName)
         .NotEmpty()
         .WithMessage("El campo usuario no puede estar vacío");

        }
    }
}
