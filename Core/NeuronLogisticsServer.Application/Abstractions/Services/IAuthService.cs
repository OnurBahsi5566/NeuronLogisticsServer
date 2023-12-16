using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.GoogleLoginDto;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto;

namespace NeuronLogisticsServer.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<GoogleLoginResponseDto> GoogleLoginAsync(GoogleLoginRequestDto model, int accessTokenLifeTime);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto model, int accessTokenLifeTime);
    }
}
