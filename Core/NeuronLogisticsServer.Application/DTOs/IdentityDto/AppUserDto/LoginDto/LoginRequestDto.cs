
namespace NeuronLogisticsServer.Application.DTOs.IdentityDto.AppUserDto.LoginDto
{
    public class LoginRequestDto
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }
    }
}