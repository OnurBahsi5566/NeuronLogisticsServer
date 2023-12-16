using NeuronLogisticsServer.Application.DTOs;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.LoginCommand
{
    public class LoginCommandResponse
    {
        public Token Token { get; set; }
    }
}