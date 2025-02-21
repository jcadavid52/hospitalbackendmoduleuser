
using HospitalModuleUser.Applica.Account.CommandHandler.Command;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Entity;
using HospitalModuleUser.Domain.Entities.AccountUser.Service;
using MediatR;

namespace HospitalModuleUser.Applica.Account.CommandHandler.Handler
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommand, AccountUserDto>
    {
        private readonly AccountUserResgisterService _userResgisterService;
        public async Task<AccountUserDto> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            var userDomain = new AccountUserEntity(request.fullName, request.email, request.email,
               request.PhoneNumber, request.age, request.address);

            return await _userResgisterService.ExecuteRegisterAsync(userDomain, request.confirmPassword);
        }
    }
}
