using Microsoft.AspNetCore.Identity;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.RegisterDto;
using NeuronLogisticsServer.Domain.Entities.Identity;

namespace NeuronLogisticsServer.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
    }
}