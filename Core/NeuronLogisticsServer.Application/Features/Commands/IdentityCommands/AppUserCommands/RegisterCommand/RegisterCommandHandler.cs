using MediatR;
using Microsoft.AspNetCore.Identity;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.RegisterDto;
using NeuronLogisticsServer.Domain.Entities.Identity;


namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        readonly IAppUserService _appUserService;

        public RegisterCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        async Task<RegisterCommandResponse> IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>.Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterResponseDto responseDto =  await _appUserService.RegisterUserAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
            });

            return new()
            {
                Message = responseDto.Message,
                Succeeded = responseDto.Succeeded,
            };
        }
    }
}