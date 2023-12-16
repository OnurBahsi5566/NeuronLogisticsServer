using MediatR;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.GoogleLoginDto;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.GoogleLoginCommand
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
      readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            GoogleLoginResponseDto responseDto = await _authService.GoogleLoginAsync(new()
            {
                Id = request.Id,
                IdToken = request.IdToken,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Name = request.Name,
                Email = request.Email,
                PhotoUrl = request.PhotoUrl,
                Provider = request.Provider
            });

            return new()
            {
                Token = responseDto.Token
            };
        }
    }
}