using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.RegisterCommand;

namespace NeuronLogisticsServer.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            RegisterCommandResponse response = await _mediator.Send(registerCommandRequest);
            return Ok(response);
        }
    }
}