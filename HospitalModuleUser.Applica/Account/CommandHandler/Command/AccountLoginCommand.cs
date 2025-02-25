using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleUser.Domain.Entities.AccountUser.Model.Dto;
using MediatR;

namespace HospitalModuleUser.Applica.Account.CommandHandler.Command
{
    public record AccountLoginCommand(string userName, string password) : IRequest<ResponseAccessDto>;

}
