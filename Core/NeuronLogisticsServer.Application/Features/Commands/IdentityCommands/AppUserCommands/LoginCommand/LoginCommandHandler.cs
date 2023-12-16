using MediatR;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto;


namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDto responseDto = await _authService.LoginAsync(new()
            {
                UserNameOrEmail = request.UserNameOrEmail,
                Password = request.Password,
            });

            return new()
            {
                Token = responseDto.Token
            };
        }
    }
}