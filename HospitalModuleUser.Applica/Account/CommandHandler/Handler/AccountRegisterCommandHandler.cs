using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Applica.Account.CommandHandler.Command;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using MediatR;

namespace HospitalModuleUser.Applica.Account.CommandHandler.Handler
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommand, AccountUserDto>
    {
        public Task<AccountUserDto> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
