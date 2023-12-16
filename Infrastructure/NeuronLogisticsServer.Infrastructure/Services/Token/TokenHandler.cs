using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NeuronLogisticsServer.Application.Abstractions.Token;
using NeuronLogisticsServer.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NeuronLogisticsServer.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(AppUser user)
        {
            Application.DTOs.Token token = new();

            //SecurityKey in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimlik oluşturma
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // oluşturulacak token ayarları
            token.Expiration = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_configuration["TokenLifeTime:AccessTokenLifeTime"])); //geçerliliği gönderilen dk kadar sürsün
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow, //üretildiği anda geçeriliği devreye girsin.
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName)}
                );

            JwtSecurityTokenHandler securityTokenHandler = new();
            token.AccessToken = securityTokenHandler.WriteToken( securityToken );
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes( number );

            return Convert.ToBase64String( number );
        }
    }
}
