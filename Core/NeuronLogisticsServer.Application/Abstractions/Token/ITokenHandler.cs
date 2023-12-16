
using NeuronLogisticsServer.Domain.Entities.Identity;

namespace NeuronLogisticsServer.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(AppUser user);

        string CreateRefreshToken();
    }

}