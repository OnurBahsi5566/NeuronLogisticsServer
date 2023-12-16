using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.RegisterDto;

namespace NeuronLogisticsServer.Application.Abstractions.Services
{
    public interface IAppUserService
    {
        Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto model);
    }
}
