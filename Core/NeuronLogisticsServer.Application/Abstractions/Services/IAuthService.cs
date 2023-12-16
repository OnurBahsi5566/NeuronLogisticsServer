using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.GoogleLoginDto;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto;

namespace NeuronLogisticsServer.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<GoogleLoginResponseDto> GoogleLoginAsync(GoogleLoginRequestDto model);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto model);

        Task<LoginResponseDto> RefreshTokenLoginAsync(string refreshToken);
    }
}