using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.RegisterDto;
using NeuronLogisticsServer.Application.Exceptions;
using NeuronLogisticsServer.Domain.Entities.Identity;

namespace NeuronLogisticsServer.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IConfiguration _configuration;

        public AppUserService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FirstName + " " + model.LastName,
                Email = model.Email,
                UserName = model.UserName,
            }, model.Password);

            RegisterResponseDto response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Success! Added User";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}<br>";

            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenEndDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenEndDate.AddSeconds(Convert.ToInt32(_configuration["TokenLifeTime:AddToAccessTokenEndDate"]));
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }
    }
}