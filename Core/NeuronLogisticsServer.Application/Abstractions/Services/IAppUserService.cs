using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.RegisterDto;
using NeuronLogisticsServer.Domain.Entities.Identity;

namespace NeuronLogisticsServer.Application.Abstractions.Services
{
    public interface IAppUserService
    {
        Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto model);

        Task UpdateRefreshTokenAsync(string refreshToken,AppUser user, DateTime accessTokenEndDate);
    }
}
