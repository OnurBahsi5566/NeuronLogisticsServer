using MediatR;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.RefreshTokenLoginCommand
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDto responseDto = await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new()
            {
                Token = responseDto.Token,
            };
        }
    }
}