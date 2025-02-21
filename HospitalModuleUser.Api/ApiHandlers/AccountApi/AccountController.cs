using HospitalModuleUser.Applica.Account.CommandHandler.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalModuleUser.Api.ApiHandlers.AccountApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterCommand command)
        {
            var resultRegister = await _mediator.Send(command);

            return StatusCode(201, resultRegister);
        }
    }
}
