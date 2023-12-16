using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.Abstractions.Token;
using NeuronLogisticsServer.Application.DTOs;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.GoogleLoginDto;
using NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto;
using NeuronLogisticsServer.Application.Exceptions;
using NeuronLogisticsServer.Domain.Entities.Identity;


namespace NeuronLogisticsServer.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public async Task<GoogleLoginResponseDto> GoogleLoginAsync(GoogleLoginRequestDto model, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string?>() { _configuration["ExternalLogin:Google-ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(model.IdToken, settings);

            var info = new UserLoginInfo(model.Provider, payload.Subject, model.Provider);
            AppUser? user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        FullName = payload.Name,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogin tablosuna oluştur.
            else
                throw new AuthenticationErrorException("Invalid external authentication.");

            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime); //saniye

            return new()
            {
                Token = token,
            };
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto model, int accessTokenLifeTime)
        {
            AppUser? user = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded) //Authentication başarılı
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime); 
                return new LoginResponseDto()
                {
                    Token = token,
                };
            }

            throw new AuthenticationErrorException();
        }
    }
}