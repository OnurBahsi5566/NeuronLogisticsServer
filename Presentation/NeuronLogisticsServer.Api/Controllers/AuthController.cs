using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.GoogleLoginCommand;
using NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.LoginCommand;
using NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.RefreshTokenLoginCommand;

namespace NeuronLogisticsServer.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody]RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }
    }
}